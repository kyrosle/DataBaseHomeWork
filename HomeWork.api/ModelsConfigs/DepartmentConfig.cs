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
            builder.Property(e => e.Id).HasColumnName("department_id");
            builder.Property(e => e.Name).HasColumnName("department_name");
            builder.HasOne(e => e.Manager).WithMany().HasForeignKey("department_manager_id");
        }
    }
}
