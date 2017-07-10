using System;
using System.Collections.Generic;
using AutoMapper;
using FollowMe.Core.Domain;
using FollowMe.Infrastructure.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<IEnumerable<Category>, IEnumerable<CategoryDto>>();
            });

            Mapper.AssertConfigurationIsValid();

        }
    }
}
