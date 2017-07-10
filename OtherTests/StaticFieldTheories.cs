using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OtherTests
{
    [TestClass]
    public class StaticFieldTheories
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Act
            var example1 = new Example("Gucio");
            
            // Assert
            Assert.IsTrue(example1.GetIds().Count == 1);
            Assert.IsTrue(example1.GetList().Count == 3);

            var example2 = new Example("Maja");

            Assert.IsTrue(example2.GetIds().Count == 2);
            Assert.IsTrue(example2.GetList().Count == 4);
            Assert.AreEqual(example2.GetList().Count, 4);

            var example3 = new Example("Tosia");
            Assert.AreEqual(example2.GetList().Count, 5);
        }
    }

    public class Example
    {
        private static List<int> ids = null;
        private static List<string> list = null;

        public int Id { get; private set; }
        public string Name { get; private set; }

        public Example(string name)
        {
            Id++;
            Name = name;
            MakeList();
            MakeIds();
        }

        public List<int> GetIds()
            => ids;

        public List<string> GetList()
            => list;

        private void MakeIds()
        {
            if (ids == null)
            {
                ids = new List<int>();
            }
            ids.Add(Id);
        }

        private void MakeList()
        {
            if (list == null)
            {
                list = new List<string> {"1st", "2nd", "3rd"};
            }
            else
            {
                var next = list.Count + 1;
                list.Add(next + "th");
            }
        }
    }
}
