using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;

namespace FollowMe.Core.Repositories
{
    public interface ISessionRepository
    {
        Task<ISession> GetAsync(Guid id);
        Task<IEnumerable<ISession>> GetAsync(DateTime date);
        Task<IEnumerable<ISession>> GetAllAsync();
        Task AddAsync(ISession session);
        Task UpdateAsync(ISession session);
        Task RemoveAsync(Guid id);
    }
}
