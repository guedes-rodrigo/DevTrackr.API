﻿using DevTrackr.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackr.API.Persistence
{
    public class DevTrackrContext:DbContext
    {
        public DevTrackrContext(DbContextOptions<DevTrackrContext> options):base(options) 
        {
         
        }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageUpdate> PackagesUpdates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>(e => { 

                //e.ToTable("tb_package"); 

                e.HasKey(p=>p.Id); 
                e.HasMany(p=>p.Updates).WithOne()
                .HasForeignKey(pu=>pu.PackageId)
                .OnDelete(DeleteBehavior.Restrict);
                }); 

            builder.Entity<PackageUpdate>(e => { 
               
                e.HasKey(p=>p.Id); 
                });
        }

    }
}
