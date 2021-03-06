using System;
using System.Collections.Generic;

namespace FollowMe.Core.Domain
{
    public class Session : ISession
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string Note { get; set; }
        public IEnumerable<IPoint> GpsPoints { get; set; }

        public Session(Category category, DateTime startTime, DateTime finishTime, 
            IEnumerable<IPoint> gpsPoints, string note = "")
        {
            Id = Guid.NewGuid();
            Category = category;
            StartTime = startTime;
            FinishTime = finishTime;
            GpsPoints = gpsPoints;
            Note = note;
        }
    }
}