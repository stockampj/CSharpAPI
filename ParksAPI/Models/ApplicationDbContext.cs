using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParksAPI.Models;

namespace ParksAPI.Models
{
    public class ApplicationDbContext : DbContext
    {


        public virtual DbSet<Park> Parks { get; set; }
        public virtual DbSet<Trail> Trails { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }

        public DbSet<ParkActivity> ParkActivities {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Park>()
        //         .HasData(
        //             new Park 
        //             {
        //                 ParkId = 1, 
        //                 ParkName = "Molalla River State Park", 
        //                 Description = "The Molalla River State Park is located in U.S. state of Oregon. It is a few miles north of Canby, and half a mile from the Canby Ferry. The park is south of the Willamette River and east of the Molalla River, at the confluence of the Pudding, Molalla and Willamette rivers.",
        //                 Location = "Canby, OR 97013"
        //             },
        //             new Park 
        //             {
        //                 ParkId = 2, 
        //                 ParkName = "Cape Lookout State Park", 
        //                 Description = "A popular campground and day-use area, Cape Lookout is located on a sand spit between Netarts Bay and the ocean, giving you a terrific view of the ocean with convenient access to the beach. Note: The beach at Cape Lookout is protected by a 50' wide cobble-sized stone revetment. The revetment helps prevent erosion and stabilizes the man-made dune that protects the campground. Visitors that wish to access the beach must walk through the revetment. Please be careful when on the cobble stones, as they can be unstable.",
        //                 Location = "45.36682,-123.962148"
        //             }
        //         );
            
        //     builder.Entity<Trail>()
        //         .HasData(
        //             new Trail 
        //             {
        //                 TrailId = 1, 
        //                 TrailName = "Easy River Run", 
        //                 Length = 5,
        //                 ChallengeRating = 2,
        //                 ParkId = 1
        //             },
        //             new Trail 
        //             {
        //                 TrailId = 2, 
        //                 TrailName = "Cape Lookout Trail", 
        //                 Length = 2.4,
        //                 ChallengeRating = 4,
        //                 ParkId = 2
        //             },
        //             new Trail 
        //             {
        //                 TrailId = 3, 
        //                 TrailName = "The Nature Trail", 
        //                 Length = 1.7,
        //                 ChallengeRating = 1,
        //                 ParkId = 2
        //             },
        //             new Trail 
        //             {
        //                 TrailId = 4, 
        //                 TrailName = "Cape Trail Heights", 
        //                 Length = 17,
        //                 ChallengeRating = 5,
        //                 ParkId = 2
        //             }
        //         );

        // }
    }
}