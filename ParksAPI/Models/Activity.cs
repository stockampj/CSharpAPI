using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParksAPI.Models
{
  public class Activity
  {
    // public Activity()
    // {
    //   this.Parks = new HashSet<ParkActivity>();
    // }
    public int ActivityId { get; set; }
    public string ActivityName { get; set; }
    // public virtual ICollection<ParkActivity> Parks {get; set;}
  }

}

