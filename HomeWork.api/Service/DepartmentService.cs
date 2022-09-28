using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public DepartmentService(MyDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        /// <summary>
        /// 添加 Department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddAsync(DepartmentDto model)
        {
            try
            {
                bool isExist = await db.Departments.AsNoTracking().AnyAsync(dp => dp.Name.Trim().Equals(model.Name));
                if (isExist)
                {
                    return new ApiResponse("Department is Existed");
                }

                var department = mapper.Map<Department>(model);
                await db.Departments.AddAsync(department);
                await db.SaveChangesAsync();
                return new ApiResponse(true, "Department Added");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 删除 id 的 department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var department = await db.Departments.SingleAsync(dp => dp.Id.Equals(id));
                db.Departments.Remove(department);
                var result = await db.SaveChangesAsync();
                return new ApiResponse(true, $"Delete {result} Records");
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 获取 所有 Departement 信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                IQueryable<DepartmentDto> departmentDtosQuery = from dp in db.Departments
                                                                join st in db.Staffs on dp.ManagerId equals st.Id
                                                                select new DepartmentDto()
                                                                {
                                                                    Id = dp.Id,
                                                                    Name = dp.Name,
                                                                    ManagerId = st.Id,
                                                                    ManagerName = st.Name
                                                                };
                var departmentDtosSplitedPage = departmentDtosQuery
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize)
                    .Where(dp => string.IsNullOrWhiteSpace(parameter.Search) || dp.Name.Trim().Contains(parameter.Search));
                var departmentDtos = await departmentDtosSplitedPage.ToArrayAsync();
                return new ApiResponse(true, departmentDtos);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 获取 id 的 Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var department = await db.Posts.SingleAsync(dp => dp.Id.Equals(id));
                var departmentDto = mapper.Map<DepartmentDto>(department);
                return new ApiResponse(true, departmentDto);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        /// <summary>
        /// 更新 id 的 Department 信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateAsync(DepartmentDto model)
        {
            try
            {
                var department = mapper.Map<Department>(model);
                db.Departments.Update(department);
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
