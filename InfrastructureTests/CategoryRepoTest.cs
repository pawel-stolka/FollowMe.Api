using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FollowMe.Core.Repositories;
using FollowMe.Infrastructure.Repositories;
using FollowMe.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfrastructureTests
{
    [TestClass]
    public class CategoryRepoTest
    {
        private readonly ICategoryService categoryService;
        private ICategoryRepository repository;

        public CategoryRepoTest()//IMapper mapper)
        {
            repository = new InMemoryCategoryRepo();
            categoryService = new CategoryService(repository); //, mapper);
        }

        [TestMethod]
        public async Task DoesItPassThroughAllTiers()
        {
            // Assign
            var expected = "Luźnym krokiem...";

            // Act
            var run = await categoryService.GetAsync("spacer");

            // Assert
            Assert.AreEqual(expected, run.Description);
        }

        //[TestMethod]
        //public async Task DoesItAddNewCategory()
        //{
        //    // Assign
        //    //var categories = categoryService.Get()
        //    var before = await repository.GetAllAsync().Count();
        //    await categoryService.RegisterAsync("New category", "add test");
        //    var after = await repository.GetAllAsync().Count();

        //    // Act

        //    var actual = categoryService.Get("New category");

        //    // Assert
        //    Assert.AreEqual("New category", actual.Name);
        //    Assert.AreEqual("add test", actual.Description);


        //    Assert.IsTrue(after == before + 1);
        //}

        //[TestMethod]
        //public void DoesntAddExistingCategory()
        //{
        //    // Assign
        //    Exception expectedException = null;
            
        //    // Act
        //    try
        //    {
        //        categoryService.RegisterAsync("Spacer", "duplication");
        //    }
        //    catch (Exception ex)
        //    {
        //        expectedException = ex;
        //    }

        //    // Assert
        //    Assert.IsNotNull(expectedException);
        //}
    }
}
