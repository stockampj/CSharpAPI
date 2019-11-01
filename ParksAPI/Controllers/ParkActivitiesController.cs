using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ParksAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParkActivitiesController : ControllerBase
    {
        private ApplicationDbContext _db;

        public ParkActivitiesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParkActivity>> Get(string parkId, string activityId)
        {
            var query = _db.ParkActivities.AsQueryable();

            if( parkId != null)
            {
            int parkIdint = Int32.Parse(parkId);
            query = query
                .Include(pA => pA.Activity)
                .Where(p => p.ParkId == parkIdint);
            }

            if( activityId != null)
            {
            Console.WriteLine("HHHHHHHHHHHHEEEEEEEEEEEEELLLLLLLLLLLLLLLLOOOOOOOOOOOOOOOOOOOOO");

            int activityIdInt = Int32.Parse(activityId);

            query = query
                .Include(pA => pA.Park)
                .Where(p => p.ActivityId == activityIdInt);
            }

            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] ParkActivity parkActivity)
        {
            _db.ParkActivities.Add(parkActivity);
            _db.SaveChanges();

        }
    }
}