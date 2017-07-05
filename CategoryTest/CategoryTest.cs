using System;
using FollowMe.Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CategoryTest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void GuidIsUnique()
        {
            // Assign

            // Act
            var category1 = new Category("test1");
            var category2 = new Category("test2");

            // Assert
            Assert.AreNotEqual(category1.Id, category2.Id);
        }
    }
}
