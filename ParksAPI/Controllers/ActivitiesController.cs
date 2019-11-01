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
    public class ActivitiesController : ControllerBase
    {
        private ApplicationDbContext _db;

        public ActivitiesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> Get(string activityName, string activityId)
        {
            var query = _db.Activities.AsQueryable();

            if(activityName != null)
            {
              query = query
                .Where(entry =>EF.Functions.Like(entry.ActivityName, "%"+activityName+"%"));
            }

            if( activityId != null)
            {
            int activityIdint = Int32.Parse(activityId);
            query = query
                .Where(activity => activity.ActivityId == activityIdint);
            }

            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Activity activity)
        {
            _db.Activities.Add(activity);
            _db.SaveChanges();

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Activity activity)
        {
            activity.ActivityId = id;
            _db.Entry(activity).State = EntityState.Modified;
            _db.SaveChanges();

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var activityToDelete = _db.Activities.FirstOrDefault(entry => entry.ActivityId == id);
            _db.Activities.Remove(activityToDelete);
            _db.SaveChanges();
        }
    }
}