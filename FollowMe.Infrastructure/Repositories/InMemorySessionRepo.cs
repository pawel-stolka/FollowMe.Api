using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;

namespace FollowMe.Infrastructure.Repositories
{
    public class InMemorySessionRepo : ISessionRepository
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category("Bieganie", "Treningi i zawody"),
            new Category("Spacer", "Luźnym krokiem..."),
            new Category("Kolarstwo", "Rowerkiem"),
            new Category("Trening siłowy", "Kalistenika"),
            new Category("Inne", "Pozostała aktywność")
        };

        private static List<ISession> _sessions = null;

        public InMemorySessionRepo()
        {
            MakeSessions();
        }

        private static void MakeSessions()
        {
            if (_sessions == null)
            {
                var time1 = DateTime.Parse("2017/07/04 21:46:00");
                var time2 = time1.AddMinutes(50);
                var time3 = time1.AddDays(1);
                var time4 = time3.AddMinutes(75);
                var gpsPoints = new List<IPoint>
                {
                    new Point(time1, 51.01, 19.02, 192.0),
                    new Point(time2, 51.1, 19.2, 200.0)
                };

                _sessions = new List<ISession>
                {
                    new Session(_categories[2], time1, time2, gpsPoints),
                    new Session(_categories[3], time3, time4, gpsPoints)
                };
            }
        }

        public async Task<ISession> GetAsync(Guid id)
            => await Task.FromResult(_sessions.SingleOrDefault(s => s.Id == id));

        public async Task<IEnumerable<ISession>> GetAsync(DateTime date)
            => await Task.FromResult(_sessions.Where(s => s.StartTime.Date == date));

        public async Task<IEnumerable<ISession>> GetAllAsync()
            => await Task.FromResult(_sessions);

        public async Task AddAsync(ISession session)
            => await Task.Run(() =>_sessions.Add(session));

        public async Task UpdateAsync(ISession session)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id)
        {
            var session = await GetAsync(id);
            _sessions.Remove(session);
        }
    }
}
