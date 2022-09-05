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
            builder.Property(s => s.Id).HasColumnName("staff_id");
            builder.Property(s => s.Name).HasColumnName("staff_name");
            builder.Property(s => s.Brith).HasColumnName("staff_brithdate");
            builder.Property(s => s.Health).HasColumnName("staff_health");

            builder.HasOne(s => s.PoliticalType).WithMany();

            builder.HasOne(e => e.Post).WithMany();

            builder.HasOne(st => st.Department).WithOne(dp => dp.Manager).HasForeignKey<Staff>(st => st.DepartmentId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
