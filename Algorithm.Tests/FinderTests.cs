using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algorithm.Test
{
    [TestClass]
    public class FinderTests
    {
        [TestMethod]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.Find(SearchType.Closest);

            Assert.IsNull(result.Oldest);
            Assert.IsNull(result.Younger);
        }

        [TestMethod]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new Finder(list);

            var result = finder.Find(SearchType.Closest);

            Assert.IsNull(result.Oldest);
            Assert.IsNull(result.Younger);
        }

        [TestMethod]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new Finder(list);

            var result = finder.Find(SearchType.Closest);

            Assert.AreSame(sue, result.Oldest);
            Assert.AreSame(greg, result.Younger);
        }

        [TestMethod]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new Finder(list);

            var result = finder.Find(SearchType.Furthest);

            Assert.AreSame(greg, result.Oldest);
            Assert.AreSame(mike, result.Younger);
        }

        [TestMethod]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(SearchType.Furthest);

            Assert.AreSame(sue, result.Oldest);
            Assert.AreSame(sarah, result.Younger);
        }

        [TestMethod]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(SearchType.Closest);

            Assert.AreSame(sue, result.Oldest);
            Assert.AreSame(greg, result.Younger);
        }

        private Person sue = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        private Person greg = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        private Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        private Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}