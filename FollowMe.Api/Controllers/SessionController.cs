using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.Commands;
using FollowMe.Infrastructure.Commands.Session;
using FollowMe.Infrastructure.DTO;
using FollowMe.Infrastructure.Services;

namespace FollowMe.Api.Controllers
{
    public class SessionController : ApiController
    {
        private readonly ISessionService _sessionService;
        private readonly ICommandDispatcher _commandDispatcher;

        public SessionController(ISessionService sessionService,
            ICommandDispatcher commandDispatcher)
        {
            _sessionService = sessionService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public async Task<IEnumerable<SessionDto>> Get()
            => await _sessionService.GetAllAsync();

        [HttpGet]
        public async Task<SessionDto> Get(Guid id)
            => await _sessionService.GetAsync(id);

        [HttpGet]
        public async Task<IEnumerable<SessionDto>> Get(DateTime dateTime)
            => await _sessionService.GetAsync(dateTime);

        [HttpPost]
        public async Task Post([FromBody] CreateSession command)
            => await _commandDispatcher.DispatchAsync(command);
        //{
        //    command = new CreateSession
        //    {
        //        Category = new Category("catFromCtrller", "none."),
        //        StartTime = DateTime.UtcNow,
        //        FinishTime = DateTime.UtcNow.AddHours(1),
        //        Note = "Me, myself dont know",
        //        GpsPoints = null
        //    };
        //    return await Task.FromResult(_commandDispatcher.DispatchAsync(command));

            //=>
            //await _commandDispatcher.DispatchAsync(new CreateSession
            //{
            //    Category = new Category("catFromCtrller", "none."),
            //    StartTime = DateTime.UtcNow,
            //    FinishTime = DateTime.UtcNow.AddHours(1),
            //    Note = "Me, myself dont know",
            //    GpsPoints = null
            //});
    }
}
