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
            builder.Property(pt => pt.StandSalary).HasColumnName("post_stand_salary");
        }
    }
}
