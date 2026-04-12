using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class RentalPeriodConfiguration : IEntityTypeConfiguration<RentalPeriod>
    {
        public void Configure(EntityTypeBuilder<RentalPeriod> builder)
        {
            builder.HasKey(r => r.PeriodId);

            builder.ToTable(p => p.HasCheckConstraint("CK_RentalPeriod_RentalPriceBYN_Min", "[RentalPriceBYN] >= 0"));

            builder.ToTable(r => r.HasCheckConstraint("CK_RentalPeriod_DateTimeStart_LessThan_DateTimeEnd", "[DateTimeStart] <= [DateTimeEnd]"));

            builder.Property(p => p.RentalPriceBYN)
                .HasPrecision(18, 2);
        }
    }
}
