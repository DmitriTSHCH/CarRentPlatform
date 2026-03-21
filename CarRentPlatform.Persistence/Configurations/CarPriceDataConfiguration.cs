using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class CarPriceDataConfiguration : IEntityTypeConfiguration<CarPriceData>
    {
        public void Configure(EntityTypeBuilder<CarPriceData> builder)
        {
            builder.HasKey(p => p.CarId);

            builder.Property(p => p.PricePerDayBYN)
                .HasPrecision(18, 2);

            builder.Property(p => p.LateReturnPenaltyPerDayBYN)
                .HasPrecision(18, 2);

            builder.ToTable(p => p.HasCheckConstraint("CK_CarPriceData_PricePerDayBYN_Min", "[PricePerDayBYN] >= 0"));

            builder.ToTable(p => p.HasCheckConstraint("CK_CarPriceData_LateReturnPenaltyPerDayBYN_Min", "[LateReturnPenaltyPerDayBYN] >= 0"));
        }
    }
}
