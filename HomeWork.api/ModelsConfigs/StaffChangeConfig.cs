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
            builder.Property(stc => stc.Id).HasColumnName("staffchange_id");
            builder.Property(stc => stc.ChangeTime).HasColumnName("staffchange_change_time").ValueGeneratedOnAdd();
            builder.Property(stc => stc.StaffId).HasColumnName("staffchange_staff_id");
            builder.Property(stc => stc.DepartmentId).HasColumnName("staffchange_department_id");

            builder.HasOne<Department>().WithMany().HasForeignKey(stc => stc.DepartmentId);
            builder.HasOne<Staff>().WithMany().HasForeignKey(stc => stc.StaffId);
        }
    }
}
