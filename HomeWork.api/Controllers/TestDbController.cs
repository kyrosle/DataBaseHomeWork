using HomeWork.api.Context;
using HomeWork.api.Models;
using HomeWork.api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeWork.Api.Service;

namespace HomeWork.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class TestDbController : ControllerBase
    {
        private readonly MyDbContext db;
        private readonly IDapperService dapper;
        private readonly IServiceProvider provider;

        public TestDbController(MyDbContext db, IDapperService dapper, IServiceProvider provider)
        {
            this.db = db;
            this.dapper = dapper;
            this.provider = provider;
        }
        [HttpGet]
        public async Task<ApiResponse> Test()
        {
            var staff = await db.Staffs.FirstOrDefaultAsync();
            return new ApiResponse(true, staff);
        }

        //    [HttpGet]
        //    public async Task<ApiResponse> TestDapper()
        //    {
        //        return new ApiResponse(true, await dapper.Action());
        //    }

        //[HttpGet]
        //public async Task<ApiResponse> TestInsertEfcore()
        //{
        //    var staff = await db.Staffs.Where(s => s.Id == 1).FirstOrDefaultAsync();
        //    var atsType = await db.AttendanceStatuses.Where(ats => ats.Id == 2).FirstOrDefaultAsync();
        //    db.Attendances.Add(new Attendance
        //    {
        //        Staff = staff!,
        //        AttendanceStatus = atsType!,
        //        RecordTime = DateTime.Now,
        //        CountTime = 100
        //    });
        //    await db.SaveChangesAsync();
        //    var result = await db.Attendances.FirstAsync();
        //    return new ApiResponse(true, result);
        //}
        [HttpGet]
        public async Task<ApiResponse> InitDatabase()
        {
            // get political and attendance Types
            var politicalType = db.Politicals.Where(e => true).ToArray();
            var attendanceType = db.AttendanceStatuses.Where(e => true).ToArray();

            // add two Post staff salary
            var saraly1 = new StaffSalary { Salary = 10000 };
            var saraly2 = new StaffSalary { Salary = 20000 };

            await db.Salarys.AddRangeAsync(saraly1, saraly2);
            await db.SaveChangesAsync();

            // add two Post
            var post1 = new Post { Name = "Post1", SaralyId = saraly1.SalaryId };
            var post2 = new Post { Name = "Post2", SaralyId = saraly2.SalaryId };

            // add two department
            var department1 = new Department { Name = "Department1" };
            var department2 = new Department { Name = "Department2" };

            await db.Departments.AddRangeAsync(department1, department2);
            await db.Posts.AddRangeAsync(post1, post2);
            await db.SaveChangesAsync();

            // add two staff manager
            var manager1 = new Staff
            {
                Name = "Manager1",
                PostId = post1.Id,
                DepartmentId = department1.Id,
                Health = "good",
                Brith = DateTime.Now,
                PoliticalType = politicalType[1].Id
            };
            var manager2 = new Staff
            {
                Name = "Manager2",
                PostId = post2.Id,
                DepartmentId = department2.Id,
                Health = "good",
                Brith = DateTime.Now,
                PoliticalType = politicalType[1].Id
            };
            await db.Staffs.AddRangeAsync(manager1, manager2);
            await db.SaveChangesAsync();

            department1.ManagerId = manager1.Id;
            department2.ManagerId = manager2.Id;
            await db.SaveChangesAsync();

            // add staff1 staff2
            var staff1 = new Staff
            {
                Name = "Staff1",
                PostId = post1.Id,
                DepartmentId = department1.Id,
                Health = "good",
                Brith = DateTime.Now,
                PoliticalType = politicalType[0].Id
            };
            var staff2 = new Staff
            {
                Name = "Staff2",
                PostId = post2.Id,
                DepartmentId = department2.Id,
                Health = "good",
                Brith = DateTime.Now,
                PoliticalType = politicalType[1].Id
            };
            await db.Staffs.AddRangeAsync(staff1, staff2);
            await db.SaveChangesAsync();

            // add a attendance record
            var attendance = new Attendance
            {
                StaffId = staff1.Id,
                AttendanceStatusId = attendanceType[1].Id,
                RecordTime = DateTime.Now,
                CountTime = 100
            };

            await db.Attendances.AddAsync(attendance);
            await db.SaveChangesAsync();
            return new ApiResponse(true, "Success");
        }

        [HttpGet]
        public async Task<ApiResponse> TestUser()
        {
            var staffs = from staff in db.Staffs
                         join post in db.Posts on staff.PostId equals post.Id
                         join department in db.Departments on staff.DepartmentId equals department.Id
                         select new { StaffName = staff.Name, PostName = post.Name, DepartmentName = department.Name };
            return new ApiResponse(true, staffs);
        }
        [HttpGet]
        public async Task<ApiResponse> TestDepartment()
        {
            // 利用匿名类 消除 orm model 序列化时候带来的循环引用
            //var departments = await db.Departments.Include(dp => dp.Staffs).Select(s => new
            //{
            //    Department_Id = s.Id,
            //    Department_Name = s.Name,
            //    Department_Staffs = s.Staffs.Select(st => new
            //    {
            //        Staff_Id = st.Id,
            //        Staff_Name = st.Name,
            //        Staff_Brith = st.Brith,
            //        Staff_Post = st.Post
            //    })
            //}).ToArrayAsync();
            //var departments = await db.Departments.Select(dp => dp).ToArrayAsync();
            //var staffs = await db.Departments.Include(dp=>db.Staffs)

            // 使用 dto 分离 model 和 数据展示
            // Department : Manager 字段 为 Staff?
            // Linq 里面是否需要判空？
            //var config = (TypeAdapterConfig)provider.GetRequiredService(typeof(TypeAdapterConfig));
            //var departments = await db.Departments
            //    .Include(dp => dp.Manager)
            //    .Include(dp => dp.Manager.Post)
            //    .Include(dp => dp.Manager.Department)
            //    .Select(dp => dp).ToArrayAsync();
            //! post 实体 为 null
            //var departmentsQuery = from dp in db.Departments
            //                       join staff in db.Staffs on dp.Manager.Id equals staff.Id
            //                       select dp;
            //var departments = await departmentsQuery.ToArrayAsync();
            //List<DepartmentDto> result = new();
            //foreach (var dp in departments)
            //{
            //    Console.WriteLine(dp.Manager.Post.Name);
            //    var item = dp.Adapt<DepartmentDto>(config);
            //    result.Add(item);
            //}
            var result = from department in db.Departments
                         join manager in db.Staffs on department.ManagerId equals manager.Id
                         select new { DepartmentName = department.Name, ManagerName = manager.Name };
            return new ApiResponse(true, result);
        }
    }
}
