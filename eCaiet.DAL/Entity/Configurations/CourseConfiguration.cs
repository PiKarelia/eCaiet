using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCaiet.DAL.Entity.Configurations
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasKey(c => c.Guid);
            
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .HasIndex(c => c.Name);

            builder
                .Property(c => c.Description)
                .HasMaxLength(500);

            builder
                .Property(c => c.CreationDate)
                .IsRequired();

            builder
                .Property(c => c.LastUpdateDate)
                .IsRequired();

            //test if Public(bool) will be not null

            builder
                .HasOne(u => u.User)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.UserGuid);
        }
    }
}
