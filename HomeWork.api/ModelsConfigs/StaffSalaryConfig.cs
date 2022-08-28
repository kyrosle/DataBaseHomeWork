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
        }
    }
}
