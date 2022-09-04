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
        private readonly IDapperService dapper;

        public HomeController(MyDbContext db, IDapperService dapper)
        {
            this.db = db;
            this.dapper = dapper;
        }
        [HttpGet]
        public async Task<ApiResponse> Test()
        {
            var staff = await db.Staffs.FirstOrDefaultAsync();
            return new ApiResponse(true, staff);
        }

        [HttpGet]
        public async Task<ApiResponse> TestDapper()
        {
            return new ApiResponse(true, await dapper.Action());
        }

        [HttpGet]
        public async Task<ApiResponse> TestInsertEfcore()
        {
            var staffs = db.Staffs.Where(s=> s.Id == 1).FirstOrDefaultAsync();
            return new ApiResponse(true, staffs);
        }
    }
}
