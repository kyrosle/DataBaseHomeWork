using HomeWork.Api.Service;
using HomeWork.Share.Dtos;
using HomeWork.Share.Parmeters;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Api.Controllers
{
    [ApiController]
    [Route("ap/[controller]/[action]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService service;

        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await service.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAllDepartment([FromQuery] QueryParameter parameter) => await service.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] DepartmentDto department) => await service.AddAsync(department);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] DepartmentDto department) => await service.UpdateAsync(department);

        [HttpGet]
        public async Task<ApiResponse> Delete(int id) => await service.DeleteAsync(id);
    }
}
