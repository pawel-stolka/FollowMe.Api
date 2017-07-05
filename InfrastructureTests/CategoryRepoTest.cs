using System;
using System.Linq;
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

        public CategoryRepoTest()
        {
            repository = new InMemoryCategoryRepo();
            categoryService = new CategoryService(repository);
        }

        [TestMethod]
        public void DoesItPassThroughAllTiers()
        {
            // Assign
            var expected = "Luźnym krokiem...";

            // Act
            var run = categoryService.Get("Spacer");

            // Assert
            Assert.AreEqual(expected, run.Description);
        }

        [TestMethod]
        public void DoesItAddNewCategory()
        {
            // Assign
            //var categories = categoryService.Get()
            var before = repository.GetAll().Count();
            categoryService.Register("New category", "add test");
            var after = repository.GetAll().Count();

            // Act

            var actual = categoryService.Get("New category");

            // Assert
            Assert.AreEqual("New category", actual.Name);
            Assert.AreEqual("add test", actual.Description);


            Assert.IsTrue(after == before + 1);
        }

        [TestMethod]
        public void DoesntAddExistingCategory()
        {
            // Assign
            Exception expectedException = null;
            
            // Act
            try
            {
                categoryService.Register("Spacer", "duplication");
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            // Assert
            Assert.IsNotNull(expectedException);
        }
    }
}
