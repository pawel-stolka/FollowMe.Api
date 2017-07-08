using System;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using AutoMapper;
using FollowMe.Core.Domain;

namespace FollowMe.MsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task MS_register_async_should_invoke_add_async_on_repository()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();

            var categoryService = new CategoryService(categoryRepositoryMock.Object);
            await categoryService.RegisterAsync("next one", "next category");

            categoryRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Category>()),
                Times.Once);
        }
    }
}
