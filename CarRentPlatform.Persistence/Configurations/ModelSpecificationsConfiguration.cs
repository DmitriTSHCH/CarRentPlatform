using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentPlatform.Persistence.Configurations
{
    internal class ModelSpecificationsConfiguration : IEntityTypeConfiguration<ModelSpecifications>
    {
        public void Configure(EntityTypeBuilder<ModelSpecifications> builder)
        {
            builder.HasKey(s => s.ModelId);

            builder.Ignore(s => s.TankUnit);

            builder.ToTable(s => s.HasCheckConstraint("CK_ModelSpecifications_NumberOfSeatsWithDriver_Min", "[NumberOfSeatsWithDriver] >= 1"));

            builder.ToTable(s => s.HasCheckConstraint("CK_ModelSpecifications_TrunkVoluem_Min", "[TrunkVoluem] >= 0"));

            builder.ToTable(s => s.HasCheckConstraint("CK_ModelSpecifications_TankCapacity_Min", "[TankCapacity] >= 0"));

            builder.ToTable(s => s.HasCheckConstraint("CK_ModelSpecifications_CityConsumptionPer100km_Min", "[CityConsumptionPer100km] >= 0"));

            builder.ToTable(s => s.HasCheckConstraint("CK_ModelSpecifications_HighwayConsumptionPer100km_Min", "[HighwayConsumptionPer100km] >= 0"));

            builder.ToTable(s => s.HasCheckConstraint("CK_ModelSpecifications_CityRangeKm_Min", "[CityRangeKm] >= 0"));

            builder.ToTable(s => s.HasCheckConstraint("CK_ModelSpecifications_HighwayRangeKm_Min", "[HighwayRangeKm] >= 0"));
        }
    }
}
