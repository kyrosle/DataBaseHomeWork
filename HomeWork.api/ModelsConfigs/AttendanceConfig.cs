using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("T_Attendance");

            builder.Property(e => e.RecordTime).HasColumnName("record_time");
            builder.Property(e => e.CountTime).HasColumnName("count_time");

            builder.HasOne(at => at.AttendanceStatus).WithMany().HasForeignKey("attendance_id");
            builder.HasOne(at => at.Staff).WithMany().HasForeignKey("staff_id");


            builder.HasData(new object[]
            {
            });
        }
    }
}
