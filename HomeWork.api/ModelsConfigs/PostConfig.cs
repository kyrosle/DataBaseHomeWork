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
            builder.Property(e => e.Id).HasColumnName("post_id");
            builder.Property(e => e.Name).HasColumnName("post_name");
            builder.Property(e => e.SalaryId).HasColumnName("post_salary_id");
            builder.HasData(new object[]
            {
                new Post()
                {
                    Id=1,
                    Name="Post1",
                    SalaryId=1
                },
                new Post()
                {
                    Id=2,
                    Name="Post2",
                    SalaryId=1
                }
            });
        }
    }
}
