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
            builder.Property(e => e.ChangeTime).HasColumnName("change_time").ValueGeneratedOnAdd();

            builder.HasOne<Department>().WithMany().HasForeignKey("department_id");
            builder.HasOne<Staff>().WithMany().HasForeignKey("staff_id");
        }
    }
}
