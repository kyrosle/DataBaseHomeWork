using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("T_Post");
            builder.Property(pt => pt.Id).HasColumnName("post_id");
            builder.Property(pt => pt.Name).HasColumnName("post_name");
            builder.Property(pt => pt.SaralyId).HasColumnName("post_staff_salary_id");

            builder.HasOne<StaffSalary>().WithMany().HasForeignKey(pt => pt.SaralyId);
        }
    }
}
