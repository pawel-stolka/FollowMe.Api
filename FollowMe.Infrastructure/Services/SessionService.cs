using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.DTO;

namespace FollowMe.Infrastructure.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)//, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IEnumerable<SessionDto>> GetAllAsync()
        {
            var sessions = await _sessionRepository.GetAllAsync();

            //var sessionsDto 

            var sessionDto = sessions.Select(session =>
                new SessionDto
                {
                    Id = session.Id,
                    Category = new CategoryDto
                    {
                        Id = session.Category.Id,
                        Name = session.Category.Name,
                        Description = session.Category.Description
                    },
                    StartTime = session.StartTime,
                    FinishTime = session.FinishTime,
                    GpsPoints = session.GpsPoints.Select(point => new PointDto
                    {
                        Id = point.Id,
                        DateTime = point.DateTime,
                        Latitude = point.Latitude,
                        Longitude = point.Longitude,
                        Altitude = point.Altitude,
                        Distance = point.Distance
                    }).ToList(),
                    Note = session.Note
                });

            return sessionDto;
        }

        public async Task<SessionDto> GetAsync(Guid id)
        {
            var session = await _sessionRepository.GetAsync(id);
            // It doesnt work, at least throug AutoFac !!!
            //var categoryDto = Mapper.Map<CategoryDto>(session.Category);
            //var pointsDto = Mapper.Map<IEnumerable<PointDto>>(session.GpsPoints);

            return new SessionDto
            {
                Id = session.Id,
                Category = new CategoryDto
                {
                    Id = session.Category.Id,
                    Name = session.Category.Name,
                    Description = session.Category.Description
                },
                StartTime = session.StartTime,
                FinishTime = session.FinishTime,
                GpsPoints = session.GpsPoints.Select(point => new PointDto
                {
                    Id = point.Id,
                    DateTime = point.DateTime,
                    Latitude = point.Latitude,
                    Longitude = point.Longitude,
                    Altitude = point.Altitude,
                    Distance = point.Distance
                }).ToList(),
                Note = session.Note
            };
        }

        public async Task<IEnumerable<SessionDto>> GetAsync(DateTime date)
        {
            var sessions = await _sessionRepository.GetAsync(date.Date);
            var list = new List<SessionDto>();
            foreach (var session in sessions)
            {
                list.Add(
                    await GetAsync(session.Id));
            }

            return list;
        }

        public async Task RegisterAsync(Category category, DateTime startTime, DateTime finishTime, string note, ISet<IPoint> gpsPoints)
        {
            var session = new Session(category, startTime, finishTime, gpsPoints);
            await _sessionRepository.AddAsync(session);
        }
    }
}