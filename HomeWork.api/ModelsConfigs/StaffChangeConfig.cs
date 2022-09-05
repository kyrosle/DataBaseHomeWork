using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class StaffChangeConfig : IEntityTypeConfiguration<StaffChange>
    {
        public void Configure(EntityTypeBuilder<StaffChange> builder)
        {
            builder.ToTable("T_StaffChange");
            builder.HasOne(e => e.Staff).WithMany().HasForeignKey("staff_id");
            builder.HasOne(e => e.Department).WithMany().HasForeignKey("department_id");
            builder.Property(e => e.ChangeTime).HasColumnName("change_time");
        }
    }
}
