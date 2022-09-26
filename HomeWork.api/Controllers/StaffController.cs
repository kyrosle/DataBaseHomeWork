using HomeWork.Api.Service;
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
        public async Task<ApiResponse> GetAllStaff([FromQuery] QueryParameter parameter)
        {
            return await serviece.GetAllAsync(parameter);
        }
    }
}
