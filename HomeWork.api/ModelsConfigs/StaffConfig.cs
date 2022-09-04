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
            builder.Property(e => e.Id).HasColumnName("staff_id");
            builder.Property(e => e.Name).HasColumnName("staff_name");
            builder.Property(e => e.Brith).HasColumnName("staff_brithdate");
            builder.Property(e => e.PoliticalType).HasColumnName("staff_political_type");
            builder.Property(e => e.Health).HasColumnName("staff_health");
            builder.Property(e => e.PostId).HasColumnName("staff_post_id");
            builder.Property(e => e.DepartmentId).HasColumnName("staff_department_id");
            builder.HasData(new object[]
            {
                new Staff()
                {
                    Id=1,
                    Name="Staff1",
                    Brith=DateTime.Now,
                    PoliticalType=1,
                    Health="good",
                    PostId=1,
                    DepartmentId=1,
                },
                new Staff()
                {
                    Id=2,
                    Name="Staff2",
                    Brith=DateTime.Now,
                    PoliticalType=2,
                    Health="good",
                    PostId=1,
                    DepartmentId=2,

                },
            }); 
        }
    }
}
