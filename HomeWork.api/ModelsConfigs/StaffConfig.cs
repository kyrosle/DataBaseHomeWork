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
            builder.Property(st => st.Id).HasColumnName("staff_id");
            builder.Property(st => st.Name).HasColumnName("staff_name");
            builder.Property(st => st.Brith).HasColumnName("staff_brithdate");
            builder.Property(st => st.Health).HasColumnName("staff_health");

            builder.HasOne(st => st.PoliticalType).WithMany();

            builder.HasOne(st => st.Post).WithMany();

            builder.HasOne(st => st.Salary).WithMany().HasForeignKey("salary_id").OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
