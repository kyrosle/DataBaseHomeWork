using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

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
        public async Task<ApiResponse> AddAsync(StaffDto model)
        {
            try
            {
                bool isExist = db.Staffs.AsNoTracking().Where(st => st.Name.Trim().Equals(model.Name)).Any();
                if (isExist)
                {
                    return new ApiResponse("Staff is Existed");
                }

                var staff = mapper.Map<Staff>(model);
                await db.Staffs.AddAsync(staff);
                await db.SaveChangesAsync();
                return new ApiResponse(true, "Staff Added");
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
                var staff = await db.Staffs.SingleAsync(st => st.Id.Equals(id));
                if (staff is null)
                {
                    return new ApiResponse("Id not Found");
                }
                else
                {
                    db.Staffs.Remove(staff);
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
                //IQueryable<Staff> staffsQuery = db.Staffs
                //    .Skip(parameter.PageIndex * parameter.PageSize)
                //    .Take(parameter.PageSize)
                //    .Where(st => string.IsNullOrWhiteSpace(parameter.Search) || st.Name.Contains(parameter.Search));
                IQueryable<Staff> staffsQuery = from st in db.Staffs
                                                join dp in db.Departments on st.DepartmentId equals dp.Id
                                                join pt in db.Posts on st.PostId equals pt.Id
                                                select new StaffDto()
                                                {
                                                };
                var staffModels = await staffsQuery.ToArrayAsync();
                //var staffs = staffModels.Select(stm => mapper.Map<StaffDto>(stm)).ToArray();
                return new ApiResponse(true, staffs);
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
                var staff = await db.Staffs.SingleAsync(st => st.Id.Equals(id));
                if (staff is not null)
                {
                    return new ApiResponse(true, staff);
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
