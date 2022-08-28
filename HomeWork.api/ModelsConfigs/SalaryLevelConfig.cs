using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class SalaryLevelConfig : IEntityTypeConfiguration<SalaryLevel>
    {
        public void Configure(EntityTypeBuilder<SalaryLevel> builder)
        {
            builder.ToTable("T_SalaryLevel");
        }
    }
}
