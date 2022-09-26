using HomeWork.api.Context;
using HomeWork.api.Dtos;
using HomeWork.api.Models;
using HomeWork.App.Service;
using HomeWork.Share.Parmeters;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Service
{
    public class StaffService : IStaffServiece
    {
        private readonly MyDbContext db;

        public StaffService(MyDbContext db)
        {
            this.db = db;
        }
        public Task<ApiResponse> AddAsync(StaffDto model)
        {
            var staff = mapper.Map<Staff>(model);
        }

        public Task<ApiResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            throw new NotImplementedException();
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
