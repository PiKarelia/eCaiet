using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCaiet.DAL.Entity.Configurations
{
    class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder
                .HasKey(f => f.Guid);

            builder
                .Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(f => f.Name);

            builder
                .Property(f => f.ContentType)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(f => f.LastUpdateDate)
                .IsRequired();

            builder
                .Property(f => f.CreationDate)
                .IsRequired();

            builder
                .HasOne(f => f.Owner)
                .WithOne(t => t.Avartar)
                .HasForeignKey<File>(k => k.OwnerGuid)  //HasForeignKey(k => k.OwnerGuid)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(f => f.Course)
                .WithMany(c => c.Files)
                .HasForeignKey(k => k.CourseGuid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
