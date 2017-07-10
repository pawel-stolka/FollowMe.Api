using System;

namespace FollowMe.Core.Domain
{
    public interface IPoint
    {
        DateTime DateTime { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        double Altitude { get; set; }
        double Distance { get; set; }
    }
}