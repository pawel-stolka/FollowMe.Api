using System;
using System.Collections.Generic;

namespace FollowMe.Core.Domain
{
    public class Session : ISession
    {
        public Guid Id { get; set; }
        public ICategory Category { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string Note { get; set; }
        public IEnumerable<IPoint> GpsPoints { get; set; }

        public Session(ICategory category, DateTime startTime, DateTime finishTime, 
            IEnumerable<IPoint> gpsPoints, string note = "")
        {
            Id = Guid.NewGuid();
            Category = category;
            StartTime = startTime;
            FinishTime = finishTime;
            Note = note;
            GpsPoints = gpsPoints;
        }
    }
}