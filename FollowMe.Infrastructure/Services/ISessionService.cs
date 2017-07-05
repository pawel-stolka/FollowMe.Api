using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.DTO;

namespace FollowMe.Infrastructure.Services
{
    public interface ISessionService
    {
        SessionDto Get(Guid id);
        IEnumerable<SessionDto> Get(DateTime date);
        void Register(Category category, DateTime startTime, DateTime finishTime,
            string note, ISet<IPoint> gpsPoints);
    }
}
