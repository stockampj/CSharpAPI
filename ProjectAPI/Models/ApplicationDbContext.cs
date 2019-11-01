using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectAPI.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<THING> THINGS { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<THING>()
                .HasData(
                    new THING {THINGId = 1},
                );

        }
    }
}