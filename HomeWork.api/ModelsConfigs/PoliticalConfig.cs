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
        }
    }
}
