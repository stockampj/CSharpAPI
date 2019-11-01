
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParksAPI.Models
{
    public class Trail
    {   
        public int TrailId {get; set;}
        public string TrailName {get; set;}
        [Required]
        public int ParkId {get; set;}
        public double Length {get; set;}
        [Range(1, 5, ErrorMessage = "Rating must be between 1 to 5.")]
        public int ChallengeRating {get; set;}
    }
}