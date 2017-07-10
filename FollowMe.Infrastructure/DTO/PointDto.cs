using System;

namespace FollowMe.Infrastructure.DTO
{
    public class PointDto
    {
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Distance { get; set; }
    }
}