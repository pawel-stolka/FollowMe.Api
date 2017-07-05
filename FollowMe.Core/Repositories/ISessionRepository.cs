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
        ISession Get(Guid id);
        IEnumerable<ISession> Get(DateTime date);
        IEnumerable<ISession> GetAll();
        void Add(ISession session);
        void Update(ISession session);
        void Remove(Guid id);
    }
}
