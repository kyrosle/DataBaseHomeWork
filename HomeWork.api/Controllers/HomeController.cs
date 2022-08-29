using HomeWork.api.Context;
using System.Linq;
using HomeWork.api.Models;
using HomeWork.api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace HomeWork.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly MyDbContext db;

        public HomeController(MyDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ApiResponse> Test()
        {
            var staff = await db.Staffs.FirstOrDefaultAsync();
            return new ApiResponse(true, staff);
        }
    }
}
