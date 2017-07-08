using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FollowMe.Core.Domain;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using Moq;
using Xunit;

namespace FollowMe.Tests.Services
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();

            var categoryService = new CategoryService(categoryRepositoryMock.Object);
            await categoryService.RegisterAsync("next category", "next test");

            categoryRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Category>()), Times.Once);
        }
    }
}
