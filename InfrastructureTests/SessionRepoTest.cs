using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.Mappers;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfrastructureTests
{
    [TestClass]
    public class SessionRepoTest
    {
        private readonly ISessionService _sessionService;
        //private ISessionRepository repository;

        public SessionRepoTest()//IMapper mapper)
        {
            _sessionService = new SessionService(
                new InMemorySessionRepo()); //, mapper);
        }

        [TestMethod]
        public void SessionService_does_it_pass_through_all_tiers()
        {
            // Assign
            var date = DateTime.Parse("2017/07/04");// 21:46:00");

            // Act
            //var session = _sessionService.GetAsync(date).FirstOrDefault();

            // Assert
            //Assert.AreEqual("Rowerkiem", session.Category.Description);
        }
    }
}
