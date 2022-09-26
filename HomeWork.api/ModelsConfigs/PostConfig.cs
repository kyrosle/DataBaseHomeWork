﻿using HomeWork.api.Models;
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
            builder.Property(e => e.SaralyId).HasColumnName("staff_salary_id");
            builder.HasOne<StaffSalary>().WithMany().HasForeignKey(e=>e.SaralyId);
        }
    }
}
