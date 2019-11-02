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
    public class ParksController : ControllerBase
    {
        private ApplicationDbContext _db;

        public ParksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Park>> Get(string parkName, string parkId, bool parkActivity)
        {
            var query = _db.Parks.AsQueryable();
            
            if(parkName != null)
            {
              query = query
                .Include(park => park.Trails)
                .Where(entry =>EF.Functions.Like(entry.ParkName, "%"+parkName+"%"));
            }

            if(parkId != null)
            {
              int parkIdInt = Int32.Parse(parkId);
              query = query
                .Include(park => park.Trails)
                .Where(entry => entry.ParkId == parkIdInt);
            }

            if (parkActivity)
            {
              query = query
                .Include(park => park.Activities)
                .ThenInclude(join => join.Activity);
            }
            
            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Park park)
        {

            _db.Parks.Add(park);
            _db.SaveChanges();
            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Park park)
        {
            park.ParkId = id;
            _db.Entry(park).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
            _db.Parks.Remove(parkToDelete);
            _db.SaveChanges();
        }
    }
}