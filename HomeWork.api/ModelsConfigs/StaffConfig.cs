using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("T_Staff");
            builder.Property(e => e.Id).HasColumnName("staff_id");
            builder.Property(e => e.Name).HasColumnName("staff_name");
            builder.Property(e => e.Brith).HasColumnName("staff_brithdate");
            builder.Property(e => e.PoliticalType).HasColumnName("staff_political_type");
            builder.Property(e => e.Health).HasColumnName("staff_health");
            builder.Property(e => e.PostId).HasColumnName("staff_post_id");
            builder.Property(e => e.DepartmentId).HasColumnName("staff_department_id");
        }
    }
}
