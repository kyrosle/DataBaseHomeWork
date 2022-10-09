using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("T_Staff");
            builder.Property(st => st.Id).HasColumnName("staff_id");
            builder.Property(st => st.Name).HasColumnName("staff_name");
            builder.Property(st => st.Brith).HasColumnName("staff_brith");
            builder.Property(st => st.PoliticalType).HasColumnName("staff_political_type");
            builder.Property(st => st.Health).HasColumnName("staff_health");
            builder.Property(st => st.PostId).HasColumnName("staff_post_id");
            builder.Property(st => st.DepartmentId).HasColumnName("staff_department_id");
            builder.Property(st => st.Salary).HasColumnName("staff_salary");
            builder.Property(st => st.Introduce).HasColumnName("staff_introduce");
            builder.Property(st => st.IsDeleted).HasColumnName("staff_is_deleted").HasDefaultValue(false);

            builder.HasOne<Post>().WithMany().HasForeignKey(st => st.PostId);
            builder.HasOne<Department>().WithMany().HasForeignKey(st => st.DepartmentId);
        }
    }
}
