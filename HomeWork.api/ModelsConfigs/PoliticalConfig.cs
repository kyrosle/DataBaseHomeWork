using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class PoliticalConfig : IEntityTypeConfiguration<Political>
    {
        public void Configure(EntityTypeBuilder<Political> builder)
        {
            builder.ToTable("T_Political");
            builder.Property(e => e.Id).HasColumnName("political_id");
            builder.Property(e => e.EnumType).HasColumnName("political_type");
            builder.Property(e => e.IsDeleted).HasColumnName("political_is_deleted").HasDefaultValue(false);

            builder.HasData(new object[]
            {
                new Political {Id=1, EnumType="党员" },
                new Political {Id=2, EnumType="群众" }
            });
        }
    }
}
