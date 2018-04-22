using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCaiet.DAL.Entity.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Guid);

            builder
                .Property(u => u.Login)
                .IsRequired();
            builder
                .HasIndex(u => u.Login)
                .IsUnique();

            builder
                .Property(u => u.Password)
                .IsRequired();

            builder
                .Property(u => u.Email).IsRequired();
            builder
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
