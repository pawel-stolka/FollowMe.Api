using System;

namespace FollowMe.Api.Models
{
    public class Point
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Distance { get; set; }
    }
}