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
            builder.HasKey(e => e.SalaryId);
            builder.Property(e => e.SalaryId).HasColumnName("salary_id");
            builder.Property(e => e.Salary).HasColumnName("salary_value");
            builder.HasData(new object[]
            {
                new StaffSalary()
                {
                    SalaryId=1,
                    Salary=1000,
                }
            });
        }
    }
}
