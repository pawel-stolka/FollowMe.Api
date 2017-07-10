using System;

namespace FollowMe.Core.Domain
{
    public class Point : IPoint
    {
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Distance { get; set; }

        public Point(DateTime dateTime, double latitude, double longitude,
            double altitude, double distance)
        {
            DateTime = dateTime;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            Distance = distance;
        }

        public Point(DateTime dateTime, double latitude, double longitude, double distance)
            : this(dateTime, latitude, longitude, 0, distance)
        { }
    }
}