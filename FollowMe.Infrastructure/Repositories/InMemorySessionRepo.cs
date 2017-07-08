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
        private static List<Category> _categories = new List<Category>
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

        public async Task<ISession> GetAsync(Guid id)
            => await Task.FromResult(_sessions.SingleOrDefault(s => s.Id == id));

        public async Task<IEnumerable<ISession>> GetAsync(DateTime date)
            => await Task.FromResult(_sessions.Where(s => s.StartTime.Date == date));

        public async Task<IEnumerable<ISession>> GetAllAsync()
            => await Task.FromResult(_sessions);

        public async Task AddAsync(ISession session)
            => await Task.FromResult(_sessions.Add(session));

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
