using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service
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
                return new ApiResponse(true, "Staff Added");
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
                db.Staffs.Remove(staff);
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
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                //IQueryable<Staff> staffsQuery = db.Staffs
                //    .Skip(parameter.PageIndex * parameter.PageSize)
                //    .Take(parameter.PageSize)
                //    .Where(st => string.IsNullOrWhiteSpace(parameter.Search) || st.Name.Contains(parameter.Search));
                IQueryable<StaffDto> staffDtosQuery = from st in db.Staffs
                                                      join dp in db.Departments
                                                        on st.DepartmentId equals dp.Id
                                                      join pt in db.Posts
                                                        on st.PostId equals pt.Id
                                                      join pol in db.Politicals
                                                        on st.PoliticalType equals pol.Id
                                                      select new StaffDto()
                                                      {
                                                          Id = st.Id,
                                                          Name = st.Name,
                                                          Brith = st.Brith,
                                                          PoliticalType = pol.EnumType,
                                                          DepartmentId = st.DepartmentId,
                                                          DepartmentName = dp.Name,
                                                          PostId = st.PostId,
                                                          PostName = pt.Name,
                                                      };
                var staffDtosSplitedPage = staffDtosQuery
                    .AsNoTracking()
                    .Where(st => string.IsNullOrWhiteSpace(parameter.Search) || st.Name.Contains(parameter.Search))
                    .Skip(parameter.PageIndex * parameter.PageSize).Take(parameter.PageSize);
                var staffDtos = await staffDtosSplitedPage.ToArrayAsync();
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
                var staff = await db.Staffs.SingleAsync(st => st.Id.Equals(id));
                // staff 为空 throw Expection
                var staffDto = mapper.Map<StaffDto>(staff);
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
