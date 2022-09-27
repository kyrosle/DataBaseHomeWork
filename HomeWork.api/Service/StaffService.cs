using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
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
        public async Task<ApiResponse> AddAsync(StaffDto model)
        {
            try
            {
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
                var staffquery = db.Staffs.Where(st => st.Id.Equals(id));
                var result = await staffquery.ToArrayAsync();
                if(result is null)
                {
                    return new ApiResponse("Id not existed");
                }
                else
                {

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
                //var staffsQry = from staff in db.Staffs select staff;
                if (parameter.PageSize == 0) parameter.PageSize = 20;
                IQueryable<Staff> staffsQuery = db.Staffs
                    .Skip(parameter.PageIndex * parameter.PageSize)
                    .Take(parameter.PageSize)
                    .Where(st => string.IsNullOrWhiteSpace(parameter.Search) || st.Name.Contains(parameter.Search));
                var staffModels = await staffsQuery.ToArrayAsync();
                var staffs = staffModels.Select(stm => mapper.Map<StaffDto>(stm)).ToArray();
                return new ApiResponse(true, staffs);
            }
            catch (Exception e)
            {
                return new ApiResponse(e.Message);
            }
        }

        public Task<ApiResponse> GetSingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateAsync(StaffDto model)
        {
            throw new NotImplementedException();
        }
    }
}
