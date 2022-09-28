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
        public async Task<ApiResponse> AddAsync(DepartmentDto model)
        {
            try
            {
                bool isExist = db.Departments.AsNoTracking().Where(dp => dp.Name.Trim().Equals(model.Name)).Any();
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

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var department = await db.Departments.SingleAsync(dp => dp.Id.Equals(id));
                if (department is null)
                {
                    return new ApiResponse("Id not Found");
                }
                else
                {
                    db.Departments.Remove(department);
                    var result = await db.SaveChangesAsync();
                    return new ApiResponse(true, $"Delete {result} Records");
                }
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                IQueryable<DepartmentDto> departmentQuery = from dp in db.Departments
                                                            join st in db.Staffs on dp.ManagerId equals st.Id
                                                            select new DepartmentDto()
                                                            {
                                                                Id = dp.Id,
                                                                Name = dp.Name,
                                                                ManagerId = st.Id,
                                                                ManagerName = st.Name
                                                            };
                var departments = await departmentQuery.ToArrayAsync();
                // need contain post or department infomation
                //var posts = departmentModels.Select(dp => mapper.Map<De>(pt)).ToArray();
                return new ApiResponse(true, departments);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var post = await db.Posts.SingleAsync(pt => pt.Id.Equals(id));
                if (post is not null)
                {
                    return new ApiResponse(true, post);
                }
                else
                {
                    return new ApiResponse("Id not Found");
                }
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(DepartmentDto model)
        {
            try
            {
                var post = mapper.Map<Post>(model);
                db.Posts.Update(post);
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
