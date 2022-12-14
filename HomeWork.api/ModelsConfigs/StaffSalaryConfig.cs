using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class StaffSalaryConfig : IEntityTypeConfiguration<StaffSalary>
    {
        public void Configure(EntityTypeBuilder<StaffSalary> builder)
        {
            builder.ToTable("T_StaffSalary");
            builder.Property(e => e.Id).HasColumnName("salary_id");
            builder.Property(e => e.Salary).HasColumnName("salary_value");
        }
    }
}
