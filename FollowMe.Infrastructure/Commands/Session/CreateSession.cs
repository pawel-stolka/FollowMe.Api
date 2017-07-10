using FollowMe.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Infrastructure.Commands.Session
{
    public class CreateSession : ICommand
    {
        public Core.Domain.Category Category { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string Note { get; set; }
        public IEnumerable<IPoint> GpsPoints { get; set; }

        public CreateSession(Core.Domain.Category category,
            DateTime startTime, DateTime finishTime,
            IEnumerable<IPoint> points, string note = null)
        {
            Category = category;
            StartTime = startTime;
            FinishTime = finishTime;
            GpsPoints = points;
            Note = note;
        }
    }
}
