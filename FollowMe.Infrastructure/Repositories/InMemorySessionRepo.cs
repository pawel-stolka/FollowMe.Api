using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;

namespace FollowMe.Infrastructure.Repositories
{
    public class InMemorySessionRepo : ISessionRepository
    {
        private static List<ICategory> _categories = new List<ICategory>
        {
            new Category("Bieganie", "Treningi i zawody"),
            new Category("Spacer", "Luźnym krokiem..."),
            new Category("Kolarstwo", "Rowerkiem"),
            new Category("Trening siłowy", "Kalistenika"),
            new Category("Inne", "Pozostała aktywność")
        };

        private static ISet<ISession> _sessions = new HashSet<ISession>();

        public InMemorySessionRepo()
        {
            IEnumerable<IPoint> gpsPoints = new List<IPoint>();
            var time1 = DateTime.Parse("2017/07/04 21:46:00");
            _sessions.Add(
                new Session(
                    _categories[2],
                    time1, time1.AddMinutes(50),
                    gpsPoints)
                );
            _sessions.Add(
                new Session(
                    _categories[3],
                    time1.AddDays(1), time1.AddDays(1).AddMinutes(75),
                    gpsPoints)
                );
        }

        public ISession Get(Guid id)
            => _sessions.SingleOrDefault(s => s.Id == id);

        public IEnumerable<ISession> Get(DateTime date)
            => _sessions.Where(s => s.StartTime.Date == date);

        public IEnumerable<ISession> GetAll()
            => _sessions;

        public void Add(ISession session)
        {
            _sessions.Add(session);
        }

        public void Update(ISession session)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            var session = Get(id);
            _sessions.Remove(session);
        }
    }
}
