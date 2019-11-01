using System.Collections.Generic;
namespace ParkAPI.Models
{
    public class Park 
    {
        public int ParkId {get; set;}

        public Park()
        {
            this.Trails = new HashSet<Trail>();
            this.Activities = new HashSet<ParkActivity>();
        }

        public string ParkName {get; set;}
        public string Description {get; set;}
        public string Location {get; set;}
        public ICollection<Trail> Trails {get;}
        public virtual ICollection<Activity> Activities {get;}
    }
}