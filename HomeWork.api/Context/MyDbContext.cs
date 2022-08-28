using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.api.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Political> Politicals { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<SalaryLevel> SalaryLevels { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffChange> StaffChanges { get; set; }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
