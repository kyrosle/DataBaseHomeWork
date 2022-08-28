using HomeWork.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.api.ModelsConfigs
{
    public class AttendanceStatusConfig : IEntityTypeConfiguration<AttendanceStatus>
    {
        public void Configure(EntityTypeBuilder<AttendanceStatus> builder)
        {
            builder.ToTable("T_AttendanceStatus");
        }
    }
}
