using System;
using System.Collections.Generic;
using AutoMapper;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.DTO;

namespace FollowMe.Infrastructure.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<Point, PointDto>();
                cfg.CreateMap<Session, SessionDto>();
            });
        }

        public SessionDto Get(Guid id)
        {
            var session = _sessionRepository.Get(id);
            var categoryDto = Mapper.Map<CategoryDto>(session.Category);
            var pointsDto = Mapper.Map<IEnumerable<PointDto>>(session.GpsPoints);

            return new SessionDto
            {
                Id = session.Id,
                Category = categoryDto,
                StartTime = session.StartTime,
                FinishTime = session.FinishTime,
                GpsPoints = pointsDto,
                Note = session.Note
            };
        }

        public IEnumerable<SessionDto> Get(DateTime date)
        {
            var sessions = _sessionRepository.Get(date.Date);
            var list = new List<SessionDto>();
            foreach (var session in sessions)
            {
                list.Add(
                    Get(session.Id));
            }

            return list;
        }

        public void Register(Category category, DateTime startTime, DateTime finishTime, string note, ISet<IPoint> gpsPoints)
        {
            var session = new Session(category, startTime, finishTime, gpsPoints);
            _sessionRepository.Add(session);
        }
    }
}