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
            var staff = await db.Staffs.Where(s => s.Id == 1).FirstOrDefaultAsync();
            var atsType = await db.AttendanceStatuses.Where(ats => ats.Id == 2).FirstOrDefaultAsync();
            db.Attendances.Add(new Attendance
            {
                Staff = staff,
                AttendanceStatus = atsType,
                RecordTime = DateTime.Now,
                CountTime = 100
            });
            await db.SaveChangesAsync();
            var result = await db.Attendances.FirstAsync();
            return new ApiResponse(true, result);
        }
        [HttpGet]
        public async Task<ApiResponse> InitDatabase()
        {
            var politicalType = db.Politicals.Where(e => true).ToArray();
            var attendanceType = db.AttendanceStatuses.Where(e => true).ToArray();

            var saraly1 = new StaffSalary { Salary = 10000 };
            var saraly2 = new StaffSalary { Salary = 20000 };

            var post1 = new Post { Name = "Post1", Saraly = saraly1 };
            var post2 = new Post { Name = "Post2", Saraly = saraly2 };

            var department1 = new Department { Name = "Department1" };
            var department2 = new Department { Name = "Department2" };
            await db.Departments.AddRangeAsync(new Department[] { department1, department2 });

            var manager1 = new Staff { Name = "Manager1", Post = post1, Department = department1, Health = "good", Brith = DateTime.Now, PoliticalType = politicalType[1] };
            var manager2 = new Staff { Name = "Manager2", Post = post2, Department = department2, Health = "good", Brith = DateTime.Now, PoliticalType = politicalType[1] };

            await db.Staffs.AddRangeAsync(new Staff[] { manager1, manager2 });

            await db.SaveChangesAsync();

            var staff1 = new Staff { Name = "Staff1", Post = post1, Department = department1, Health = "good", Brith = DateTime.Now, PoliticalType = politicalType[0] };
            var staff2 = new Staff { Name = "Staff2", Post = post2, Department = department2, Health = "good", Brith = DateTime.Now, PoliticalType = politicalType[1] };


            department1.Manager = manager1;
            department2.Manager = manager2;

            await db.Staffs.AddRangeAsync(new Staff[] { staff1, staff2 });

            var attendance = new Attendance { Staff = staff1, AttendanceStatus = attendanceType[1], RecordTime = DateTime.Now, CountTime = 100 };

            await db.Attendances.AddAsync(attendance);

            await db.SaveChangesAsync();
            return new ApiResponse(true, "Success");
        }

        [HttpGet]
        public async Task<ApiResponse> TestUser()
        {
            var staffs = await db.Staffs.Select(s => s).ToArrayAsync();
            return new ApiResponse(true, staffs);
        }
        [HttpGet]
        public async Task<ApiResponse> TestDepartment()
        {
            var departments = await db.Departments.Include(dp=>dp.Staffs).Select(s => s.Name).ToArrayAsync();
            return new ApiResponse(true, departments);
        }
    }
}
