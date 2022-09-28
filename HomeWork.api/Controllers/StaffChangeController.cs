using HomeWork.Api.Service;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StaffChangeController : ControllerBase
    {
        private readonly IStaffChangeService service;

        public StaffChangeController(IStaffChangeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await service.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAllStaffChange([FromQuery] QueryParameter parameter) => await service.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] StaffChangeDto staffChangeDto) => await service.AddAsync(staffChangeDto);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] StaffChangeDto staffChangeDto) => await service.UpdateAsync(staffChangeDto);

        [HttpGet]
        public async Task<ApiResponse> Delete(int id) => await service.DeleteAsync(id);
    }
}
