using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_02
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BadgeNumber)
                .IsRequired()
                .HasMaxLength(50);

            
            builder.HasIndex(b => b.BadgeNumber)
                .IsUnique();

            builder.Property(b => b.IssuedAt)
                .IsRequired();

            builder.Property(b => b.Tier)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

           
            builder.HasOne(b => b.Attendee)
                .WithOne(a => a.Badge)
                .HasForeignKey<Badge>(b => b.AttendeeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(b => b.AttendeeId)
                .IsUnique();
        }
    }
}
