using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCaiet.DAL.Entity.Configurations
{
    class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder
                .HasKey(c => c.Friend1Guid);
            builder
                .HasKey(c => c.Friend2Guid);

            builder
                .HasOne(x => x.Friend1)
                .WithMany(x => x.Friends)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
