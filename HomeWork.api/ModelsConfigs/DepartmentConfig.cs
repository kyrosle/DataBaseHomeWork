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
            builder.Property(d => d.Id).HasColumnName("department_id");
            builder.Property(d => d.Name).HasColumnName("department_name");

            //builder.Property(d => d.Manager).HasForeignKey();
            builder.HasOne(dp => dp.Manager).WithOne(st => st.Department).HasForeignKey<Department>(dp => dp.ManagerId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
