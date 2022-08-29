using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class StaffChangeConfig : IEntityTypeConfiguration<StaffChange>
    {
        public void Configure(EntityTypeBuilder<StaffChange> builder)
        {
            builder.ToTable("T_StaffChange").HasNoKey();
            builder.Property(e => e.StaffId).HasColumnName("staff_id");
            builder.Property(e => e.DepartmentId).HasColumnName("department_id");
            builder.Property(e => e.ChangeTime).HasColumnName("change_time");
        }
    }
}
