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
            builder.Property(stc => stc.Id).HasColumnName("staff_change_id");
            builder.Property(stc => stc.ChangeTime).HasColumnName("staff_change_change_time").ValueGeneratedOnAdd();
            builder.Property(stc => stc.StaffId).HasColumnName("staff_change_staff_id");
            builder.Property(stc => stc.PostId).HasColumnName("staff_change_post_id");
            builder.Property(stc => stc.DepartmentId).HasColumnName("staff_change_department_id");

            builder.HasOne<Department>().WithMany().HasForeignKey(stc => stc.PostId);
            builder.HasOne<Staff>().WithMany().HasForeignKey(stc => stc.StaffId);
        }
    }
}
