using System;
using System.Collections.Generic;
using AutoMapper;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Category = FollowMe.Api.Models.Category;

namespace AutoMapperTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.Initialize((Action<IMapperConfigurationExpression>)(cfg =>
            {
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<FollowMe.Core.Domain.Category, CategoryDto>();
                cfg.CreateMap<IEnumerable<FollowMe.Core.Domain.Category>, IEnumerable<CategoryDto>>();
            }));

            Mapper.AssertConfigurationIsValid();

        }
    }
}
