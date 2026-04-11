using CarRentPlatform.Infrastructure;
using CarRentPlatform.Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {

        private readonly RoleOptions _roleOptions;
        public RoleConfiguration(RoleOptions roleOptions) 
        {
            _roleOptions = roleOptions;
        }
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(u => u.RoleNameId);

            builder.HasData(_roleOptions.Roles);
        }
    }
}
