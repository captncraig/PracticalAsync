using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using StarcraftUnits.Controllers;
using StarcraftUnits.Data;
using StarcraftUnits.Models;

namespace UnitTests
{
    [TestFixture]
    public class UnitControllerTests
    {
        private Mock<IUnitData> _db;
        private Mock<IWebServiceClient> _webService;
        private UnitsController _controller;

        [SetUp]
        public void Setup()
        {
            _db = new Mock<IUnitData>();
            _webService = new Mock<IWebServiceClient>();
            _controller = new UnitsController(_db.Object, _webService.Object);
        }

        [Test]
        public async void GetALlUnits()
        {
            IList<UnitSummary> list = new List<UnitSummary>();
            _db.Setup(x => x.GetAllUnits()).Returns(Task.FromResult(list));
            var result = await _controller.GetAllUnits();
            Assert.That(result, Is.SameAs(list));
        }
    }
}
