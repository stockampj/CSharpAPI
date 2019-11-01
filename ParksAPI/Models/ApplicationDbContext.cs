using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ParksAPI.Models
{
    public class ApplicationDbContext : DbContext
    {


        public virtual DbSet<Park> Parks { get; set; }
        public virtual DbSet<Trail> Trails { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }

        public dbSet<ParkActivity> ParkActivities {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<THING>()
            //     .HasData(
            //         new THING {THINGId = 1},
            //     );

        }
    }
}