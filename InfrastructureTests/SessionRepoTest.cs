using System;
using System.Linq;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfrastructureTests
{
    [TestClass]
    public class SessionRepoTest
    {
        private readonly ISessionService sessionService;
        private ISessionRepository repository;

        public SessionRepoTest()
        {
            repository = new InMemorySessionRepo();
            sessionService = new SessionService(repository);
        }

        [TestMethod]
        public void DoesItPassThroughAllTiers()
        {
            // Assign
            var date = DateTime.Parse("2017/07/04");// 21:46:00");

            // Act
            var session = sessionService.Get(date).FirstOrDefault();

            // Assert
            Assert.AreEqual("Rowerkiem", session.Category.Description);
        }
    }
}
