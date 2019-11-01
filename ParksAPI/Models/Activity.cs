using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkAPI.Models
{
  public class Activity
  {
    public Activity()
    {
      this.Activities = new HashSet<ParkActivity>();
    }
    public int ActivityId { get; set; }
    public string ActivityName { get; set; }
    public virtual ICollection<ParkActivity> Parks {get; set;}
  }
}