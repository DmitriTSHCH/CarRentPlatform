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
                .HasForeignKey<UserDocumentsData>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.UserCondition)
                .WithOne()
                .HasForeignKey<UserCondition>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<UserAccount>()
                .WithOne()
                .HasForeignKey<UserAccount>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Bookings)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(r => r.RoleNameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
