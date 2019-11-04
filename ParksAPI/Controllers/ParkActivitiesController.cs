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

        [HttpPost]
        public void Post([FromBody] ParkActivity parkActivity)
        {
            _db.ParkActivities.Add(new ParkActivity {ParkId = parkActivity.ParkId, ActivityId = parkActivity.ActivityId});
            _db.SaveChanges();

        }
    }
}