using CarRentPlatform.Logic.Models;
using CarRentPlatform.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence
{
    public class CarRentPlatformDbContext(DbContextOptions<CarRentPlatformDbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; }
        public DbSet<CarModel> CarModels { get; }
        public DbSet<CarPriceData> CarPriceDatas { get; }
        public DbSet<CarReservationData> CarReservationDatas { get; }
        public DbSet<ModelSpecifications> ModelSpecifications { get; }
        public DbSet<RentalPeriod> RentalPeriods { get; }
        public DbSet<User> Users { get; }
        public DbSet<UserDocumentsData> UserDocumentsDatas { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelConfiguration());
            modelBuilder.ApplyConfiguration(new CarPriceDataConfiguration());
            modelBuilder.ApplyConfiguration(new CarReservationDataConfiguration());
            modelBuilder.ApplyConfiguration(new ModelSpecificationsConfiguration());
            modelBuilder.ApplyConfiguration(new RentalPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserDocumentsDataConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
