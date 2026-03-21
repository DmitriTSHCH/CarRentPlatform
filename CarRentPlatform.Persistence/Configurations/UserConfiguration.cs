using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.HasOne(u => u.UserDocumentsData)
                .WithOne()
                .HasForeignKey<UserDocumentsData>(u => u.UserId);

            builder.HasMany(u => u.Bookings)
                .WithOne()
                .HasForeignKey(r => r.UserId);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.Email)
                .HasMaxLength(50);

            builder.Property(p => p.Rating)
                .HasPrecision(4, 2);

            builder.ToTable(p => p.HasCheckConstraint("CK_User_Rating_Range", "[Rating] >= 0 AND [Rating] <= 10"));
        }
    }
}
