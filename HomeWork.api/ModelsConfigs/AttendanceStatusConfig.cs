using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class AttendanceStatusConfig : IEntityTypeConfiguration<AttendanceStatus>
    {
        public void Configure(EntityTypeBuilder<AttendanceStatus> builder)
        {
            builder.ToTable("T_AttendanceStatus");
            builder.Property(e => e.Id).HasColumnName("attandance_status_id");
            builder.Property(e => e.EnumType).HasColumnName("attandance_status_type");
            builder.Property(e => e.FineOrBouns).HasColumnName("attendance_fine_or_bouns");
            builder.Property(e => e.RateFineOrBouns).HasColumnName("attendance_rate_fine_or_bouns");
            builder.HasData(new object[]{
                new AttendanceStatus(){Id=1, EnumType="迟到"},
                new AttendanceStatus(){Id=2, EnumType="旷工"},
                new AttendanceStatus(){Id=3, EnumType="加班"},
                new AttendanceStatus(){Id=4, EnumType=""},
            }) ;
        }
    }
}
