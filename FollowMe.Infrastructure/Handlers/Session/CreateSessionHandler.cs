using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Infrastructure.Commands;
using FollowMe.Infrastructure.Commands.Session;
using FollowMe.Infrastructure.Services;

namespace FollowMe.Infrastructure.Handlers.Session
{
    public class CreateSessionHandler : ICommandHandler<CreateSession>
    {
        private ISessionService _sessionService;

        public CreateSessionHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task HandleAsync(CreateSession command)
        {
            //await _sessionService
            //    .RegisterAsync()
            await _sessionService
                .RegisterAsync(command.Category, command.StartTime, command.FinishTime,
                    command.Note, command.GpsPoints);
            //throw new NotImplementedException();
        }
    }
}
