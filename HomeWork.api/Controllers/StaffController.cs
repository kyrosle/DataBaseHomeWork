using HomeWork.Api.Service;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffServiece service;

        public StaffController(IStaffServiece service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await service.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAllStaff([FromQuery] QueryParameter parameter) => await service.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] StaffDto staff) => await service.AddAsync(staff);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] StaffDto staff) => await service.UpdateAsync(staff);

        [HttpGet]
        public async Task<ApiResponse> Delete(int id) => await service.DeleteAsync(id);
    }
}
