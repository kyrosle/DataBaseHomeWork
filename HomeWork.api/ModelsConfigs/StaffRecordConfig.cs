using HomeWork.api.Models;
using HomeWork.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.Api.ModelsConfigs
{
    public class StaffRecordConfig : IEntityTypeConfiguration<SalaryRecord>
    {
        public void Configure(EntityTypeBuilder<SalaryRecord> builder)
        {
            builder.ToTable("T_StaffRecord");
            builder.Property(e => e.Id).HasColumnName("staff_record_id");
            builder.Property(e => e.StaffId).HasColumnName("staff_record_staff_id");
            builder.Property(e => e.Salary).HasColumnName("staff_record_salary");
            builder.Property(e => e.BillingTime).HasColumnName("staff_record_billing_time");
        }
    }
}
