using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("T_Department");
            builder.Property(dp => dp.Id).HasColumnName("department_id");
            builder.Property(dp => dp.Name).HasColumnName("department_name");

            builder.HasOne(dp => dp.Manager).WithMany().HasForeignKey("manager_id");

            builder.HasMany(dp => dp.Staffs).WithOne(st => st.Department).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
