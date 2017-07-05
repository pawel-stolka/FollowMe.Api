using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMe.Api.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string Note { get; set; }
        public IEnumerable<Point> GpsPoints { get; set; }
    }
}