using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.CarId);

            builder.HasOne(c => c.Model)
                .WithMany()
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.CarPriceData)
                .WithOne()
                .HasForeignKey<CarPriceData>(p => p.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.CarReservationData)
                .WithOne()
                .HasForeignKey<CarReservationData>(r => r.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
