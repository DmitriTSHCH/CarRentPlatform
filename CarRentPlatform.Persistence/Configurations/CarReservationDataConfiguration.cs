using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class CarReservationDataConfiguration : IEntityTypeConfiguration<CarReservationData>
    {
        public void Configure(EntityTypeBuilder<CarReservationData> builder)
        {
            builder.HasKey(e => e.CarId);

            builder.HasMany(e => e.OccupiedPeriods)
                .WithOne()
                .HasForeignKey(r => r.CarId);
        }
    }
}
