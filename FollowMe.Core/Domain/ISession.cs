using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Core.Domain
{
    public interface ISession
    {
        Guid Id { get; set; }
        ICategory Category { get; set; }
        DateTime StartTime { get; set; }
        DateTime FinishTime { get; set; }
        string Note { get; set; }
        IEnumerable<IPoint> GpsPoints { get; set; }
    }
}
