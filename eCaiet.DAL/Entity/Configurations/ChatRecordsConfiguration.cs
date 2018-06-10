using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCaiet.DAL.Entity.Configurations
{
    class ChatRecordsConfiguration : IEntityTypeConfiguration<ChatRecords>
    {
        public void Configure(EntityTypeBuilder<ChatRecords> builder)
        {
            builder
                .HasKey(c => c.Guid);


            builder
                .HasOne(u => u.Sender)
                .WithMany(c => c.ChatRecords)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
