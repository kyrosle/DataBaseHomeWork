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
            builder.Property(at => at.Id).HasColumnName("attendance_id");
            builder.Property(at => at.RecordTime).HasColumnName("attendance_record_time");
            builder.Property(at => at.CountTime).HasColumnName("attendance_count_time");
            builder.Property(at => at.AttendanceStatusId).HasColumnName("attendance_attendance_status_id");
            builder.Property(at => at.StaffId).HasColumnName("attendance_staff_id");

            builder.HasOne<Staff>().WithMany().HasForeignKey(at => at.StaffId);
            builder.HasOne<AttendanceStatus>().WithMany().HasForeignKey(at => at.AttendanceStatusId);
        }
    }
}
