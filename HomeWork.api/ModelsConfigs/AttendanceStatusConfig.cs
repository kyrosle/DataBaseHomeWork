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
            builder.Property(e => e.FineOrBouns).HasColumnName("attendance_status_fine_or_bouns");
            builder.Property(e => e.RateFineOrBouns).HasColumnName("attendance_status_rate_fine_or_bouns");
            builder.Property(e => e.IsDeleted).HasColumnName("attendance_status_is_deleted").HasDefaultValue(false);

            builder.HasData(new object[]{
                new AttendanceStatus(){Id=1, EnumType="迟到", FineOrBouns=100, RateFineOrBouns=10},
                new AttendanceStatus(){Id=2, EnumType="旷工", FineOrBouns=100, RateFineOrBouns=10},
                new AttendanceStatus(){Id=3, EnumType="加班", FineOrBouns=100, RateFineOrBouns=10},
                new AttendanceStatus(){Id=4, EnumType="请假", FineOrBouns=100, RateFineOrBouns=10},
            });
        }
    }
}
