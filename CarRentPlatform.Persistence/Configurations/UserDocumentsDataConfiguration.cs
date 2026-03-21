using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class UserDocumentsDataConfiguration : IEntityTypeConfiguration<UserDocumentsData>
    {
        public void Configure(EntityTypeBuilder<UserDocumentsData> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(u => u.FirstName)
                .HasMaxLength(30);

            builder.Property(u => u.LastName)
                .HasMaxLength(30);

            builder.Property(u => u.PassportNumber)
                .HasMaxLength(50);

            builder.Property(u => u.DriverLicenseNumber)
                .HasMaxLength(50);
        }
    }
}
