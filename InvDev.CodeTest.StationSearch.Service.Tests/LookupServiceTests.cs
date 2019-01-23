using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Net;
using NUnit.Framework;

namespace InvDev.CodeTest.StationSearch.Service.Tests
{
    [TestFixture]
    public class LookupServiceTests
    {
        [Test]
        public void SearchForXShouldReturnExpectedResults()
        {
            // arrange
            var s = new LookupService();
            var expected = new List<string>
            {
                "ZZZ"
            };

            // act
            var r = s.GetAllStartingWith("Z");

            // assert
            Assert.That(r, Is.EqualTo(expected));
        }
    }
}
