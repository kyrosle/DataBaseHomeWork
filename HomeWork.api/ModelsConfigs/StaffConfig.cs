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
            builder.Property(e => e.Health).HasColumnName("staff_health");
            builder.HasOne(e => e.Post).WithMany().HasForeignKey("staff_post_id");
            builder.HasOne(e => e.Department).WithMany().HasForeignKey("staff_department_id");
            builder.HasOne(e => e.PoliticalType).WithMany().HasForeignKey("staff_political_id");
        }
    }
}
