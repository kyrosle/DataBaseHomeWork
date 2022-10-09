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
            builder.Property(e => e.BasicSalary).HasColumnName("staff_record_basic_salary");
            builder.Property(e => e.Bouns).HasColumnName("staff_record_bouns");
            builder.Property(e => e.Fine).HasColumnName("staff_record_fine");
            builder.Property(e => e.StartTime).HasColumnName("staff_record_start_time");
            builder.Property(e => e.CutOfTime).HasColumnName("staff_record_cut_off_time");
            builder.Property(e => e.IsDeleted).HasColumnName("staff_record_is_deleted").HasDefaultValue(false);
        }
    }
}
