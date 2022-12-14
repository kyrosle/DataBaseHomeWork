using HomeWork.api.Models;
using HomeWork.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.api.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Political> Politicals { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<StaffSalary> Salarys { get; set; }
        public DbSet<SalaryRecord> SalaryRecords { get; set; }
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
