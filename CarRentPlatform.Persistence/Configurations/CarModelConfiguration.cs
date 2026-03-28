using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(m => m.ModelId);

            builder.HasOne(m => m.ModelSpecifications)
                .WithOne()
                .HasForeignKey<ModelSpecifications>(s => s.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Brand)
                .HasMaxLength(50);
            builder.Property(m => m.Model)
                .HasMaxLength(50);
        }
    }
}
