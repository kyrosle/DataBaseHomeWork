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
        private readonly IStaffServiece serviece;

        public StaffController(IStaffServiece service)
        {
            serviece = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await serviece.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAllStaff([FromQuery] QueryParameter parameter) => await serviece.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] StaffDto staff) => await serviece.AddAsync(staff);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] StaffDto staff) => await serviece.UpdateAsync(staff);

        [HttpGet]
        public async Task<ApiResponse> Delete(int id) => await serviece.DeleteAsync(id);
    }
}
