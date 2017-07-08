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
        public ISet<IPoint> GpsPoints { get; set; }

        public CreateSession()
        {
            GpsPoints = new HashSet<IPoint>();
        }
    }
}
