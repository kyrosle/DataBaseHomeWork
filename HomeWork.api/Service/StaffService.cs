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
        public Task<ApiResponse> AddAsync(StaffDto model)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
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
                    .Where(st => !string.IsNullOrWhiteSpace(parameter.Search) || st.Name.Contains(parameter.Search));
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
