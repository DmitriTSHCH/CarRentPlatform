using CarRentPlatform.Infrastructure;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence
{
    public class CarRentPlatformDbContext : DbContext
    {
        private readonly IOptions<RoleOptions> _roleOptions;
        public DbSet<Car> Cars { get; }
        public DbSet<Model> CarModels { get; }
        public DbSet<CarPriceData> CarPriceDatas { get; }
        public DbSet<CarReservationData> CarReservationDatas { get; }
        public DbSet<ModelSpecifications> ModelSpecifications { get; }
        public DbSet<RentalPeriod> RentalPeriods { get; }
        public DbSet<User> Users { get; }
        public DbSet<UserAccount> UserAccounts { get; }
        public DbSet<UserCondition> UserConditions { get; }
        public DbSet<UserDocumentsData> UserDocumentsDatas { get; }
        public DbSet<Role> Roles { get; }

        public CarRentPlatformDbContext (DbContextOptions<CarRentPlatformDbContext> options, IOptions<RoleOptions> roleOptions)
            :base(options)
        {
            _roleOptions = roleOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new CarPriceDataConfiguration());
            modelBuilder.ApplyConfiguration(new CarReservationDataConfiguration());
            modelBuilder.ApplyConfiguration(new ModelSpecificationsConfiguration());
            modelBuilder.ApplyConfiguration(new RentalPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new UserConditionConfiguration());
            modelBuilder.ApplyConfiguration(new UserDocumentsDataConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration(_roleOptions.Value));
            base.OnModelCreating(modelBuilder);
        }
    }
}
