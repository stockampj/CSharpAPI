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
    public class TrailsController : ControllerBase
    {
        private ApplicationDbContext _db;

        public TrailsController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// You may enter a String with a Park ID, length min/max, or challenge min/max to filter your searches.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Trail>> Get(string trailName, string parkId, string lengthMin, string lengthMax, string challengeMin, string challengeMax, string trailId)
        {
            var query = _db.Trails.AsQueryable();

            if(trailName != null)
            {
              query = query
                .Where(entry =>EF.Functions.Like(entry.TrailName, "%"+trailName+"%"));
            }


            if(parkId != null)
            {
            int parkIdInt = Int32.Parse(parkId);
            query = query
                .Where(trail => trail.ParkId == parkIdInt);
            }

            if(lengthMin != null)
            {
            int lengthMinInt = Int32.Parse(lengthMin);
            query = query
                .Where(trail => trail.Length >= lengthMinInt);
            }

            if(lengthMax != null)
            {
            int lengthMaxInt = Int32.Parse(lengthMax);
            query = query
                .Where(trail => trail.Length <= lengthMaxInt);
            }

            if(challengeMin != null)
            {
            int challengeMinInt = Int32.Parse(challengeMin);
            query = query
                .Where(trail => trail.ChallengeRating >= challengeMinInt);
            }

            if(challengeMax != null)
            {
            int challengeMaxInt = Int32.Parse(challengeMax);
            query = query
                .Where(trail => trail.ChallengeRating <= challengeMaxInt);
            }

            if( trailId != null)
            {
            int trailIdint = Int32.Parse(trailId);
            query = query
                .Where(trail => trail.TrailId == trailIdint);
            }

            return query.ToList();
        }
        // POST api/animals
        [HttpPost]
        public void Post([FromBody] Trail trail)
        {
            _db.Trails.Add(trail);
            _db.SaveChanges();

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trail trail)
        {
            trail.TrailId = id;
            _db.Entry(trail).State = EntityState.Modified;
            _db.SaveChanges();

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var trailToDelete = _db.Trails.FirstOrDefault(entry => entry.TrailId == id);
            _db.Trails.Remove(trailToDelete);
            _db.SaveChanges();
        }
    }
}