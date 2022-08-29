using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("T_Attendance").HasNoKey();
            builder.Property(e => e.StaffId).HasColumnName("staff_id");
            builder.Property(e => e.AttendanceType).HasColumnName("attendance_type").HasMaxLength(20);
            builder.Property(e => e.RecordTime).HasColumnName("record_time");
            builder.Property(e => e.CountTime).HasColumnName("count_time");
        }
    }
}
