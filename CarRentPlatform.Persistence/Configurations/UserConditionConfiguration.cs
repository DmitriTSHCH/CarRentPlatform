using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class UserConditionConfiguration : IEntityTypeConfiguration<UserCondition>
    {
        public void Configure(EntityTypeBuilder<UserCondition> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(p => p.Rating)
                .HasPrecision(4, 2);

            builder.ToTable(p => p.HasCheckConstraint("CK_User_Rating_Range", "[Rating] >= 0 AND [Rating] <= 10"));
        }
    }
}
