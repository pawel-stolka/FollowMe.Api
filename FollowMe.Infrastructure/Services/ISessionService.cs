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
        Task<IEnumerable<SessionDto>> GetAllAsync();
        Task<SessionDto> GetAsync(Guid id);
        Task<IEnumerable<SessionDto>> GetAsync(DateTime date);
        Task RegisterAsync(Category category, DateTime startTime, DateTime finishTime,
            string note, ISet<IPoint> gpsPoints);
    }
}
