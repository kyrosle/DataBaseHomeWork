using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service.ControllerService
{
    public class StaffService : IStaffServiece
    {
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public StaffService(MyDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        /// <summary>
        /// 添加一个Staff
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddAsync(StaffDto model)
        {
            try
            {
                // check staff whether is Existed
                bool isExist = await db.Staffs.AsNoTracking().AnyAsync(st => st.Name.Trim().Equals(model.Name));
                if (isExist)
                {
                    return new ApiResponse("Staff is Existed");
                }
                // map staffDto -> staffModel
                var staff = mapper.Map<Staff>(model);
                // add staff to ef db
                await db.Staffs.AddAsync(staff);
                await db.SaveChangesAsync();
                // return the added staff model
                return new ApiResponse(true, mapper.Map<StaffDto>(staff));
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 删除 id Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                // select single staff model
                var staff = await db.Staffs.SingleAsync(st => st.Id.Equals(id));
                // if not staff id is matched the param-id then will throw a expection nothing in seq
                // then remove the seleted staff
                db.Staffs.Remove(staff);
                // get upload the operation 
                // if it successed will return the numbers model been deleted or will return zero as failed 
                var result = await db.SaveChangesAsync();
                return new ApiResponse(true, $"Delete {result} Records");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 获取所有Staff
        /// </summary>
        /// <param name="parameter">queryed param from url</param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                // if the param-PageSize is empty, set the default size as 20
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                // make up the query which could selet all staffs in a page which size is 20
                // if less than 20 it's also run success
                IQueryable<StaffDto> staffDtosQuery =
                    from st in db.Staffs
                    join dp in db.Departments
                      on st.DepartmentId equals dp.Id
                    into dp_t
                    from dp in dp_t.DefaultIfEmpty()
                    join pt in db.Posts
                      on st.PostId equals pt.Id
                      into pt_t
                    from pt in pt_t.DefaultIfEmpty()
                    join pol in db.Politicals
                      on st.PoliticalType equals pol.Id
                    select new StaffDto(st.Id, st.Name, st.Brith, pol.EnumType, st.Health, pt.Name, dp.Name, st.Salary, st.Introduce);
                var staffDtosSplitedPage = staffDtosQuery
                    .AsNoTracking()
                    .Where(st => string.IsNullOrWhiteSpace(parameter.Search) || st.Name.Contains(parameter.Search))
                    .Skip(parameter.PageIndex * parameter.PageSize).Take(parameter.PageSize);
                var staffDtos =
                    await staffDtosSplitedPage.ToArrayAsync();
                // need contain post or department infomation
                //var staffs = staffModels.Select(stm => mapper.Map<StaffDto>(stm)).ToArray();
                return new ApiResponse(true, staffDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 获取某一id 的 Staff
        /// </summary>
        /// <param name="id">Staff Id</param>
        /// <returns></returns>
        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var staffQuery =
                    from st in db.Staffs
                    join dp in db.Departments
                        on st.DepartmentId equals dp.Id
                        into dp_t
                    from dp in dp_t.DefaultIfEmpty()
                    join pt in db.Posts on st.PostId equals pt.Id
                        into pt_t
                    from pt in pt_t.DefaultIfEmpty()
                    join ss in db.Salarys on pt.StandSalaryId equals ss.Id
                    join pol in db.Politicals
                        on st.PoliticalType equals pol.Id
                    where st.Id == id
                    select new StaffDto(st.Id, st.Name, st.Brith, pol.EnumType, st.Health, pt.Name, dp.Name, st.Salary + ss.Salary, st.Introduce);
                var staffDto = await staffQuery.AsNoTracking().SingleAsync();
                return new ApiResponse(true, staffDto);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
        /// <summary>
        /// 更新Staff数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateAsync(StaffDto model)
        {
            try
            {
                var staff = mapper.Map<Staff>(model);
                db.Staffs.Update(staff);
                var result = await db.SaveChangesAsync();
                return new ApiResponse(true, $"Updated {result} record(s)");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }
    }
}
