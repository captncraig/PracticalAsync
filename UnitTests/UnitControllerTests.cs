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
        ///Basic Test of asynchronous method. Mocking is easy, just return a task.
        /// Using Task.FromResult to make essentially a noop task.
        public async void GetALlUnits()
        {
            IList<UnitSummary> list = new List<UnitSummary>();
            _db.Setup(x => x.GetAllUnits()).Returns(Task.FromResult(list));
            var result = await _controller.GetAllUnits();
            Assert.That(result, Is.SameAs(list));
        }

        [Test]
        public void GetUnit()
        {
            var unitTcs = new TaskCompletionSource<Unit>();
            var buildingTcs = new TaskCompletionSource<string>();
            var countersTcs = new TaskCompletionSource<IList<string>>();

            //Setup mocks to return tasks from completionsources
            _db.Setup(x => x.GetUnit("marine")).Returns(unitTcs.Task);
            _webService.Setup(x => x.BuiltFrom("marine")).Returns(buildingTcs.Task);
            _webService.Setup(x => x.GetCountersFor("marine")).Returns(countersTcs.Task);

            //call controller method. Should not be complete, but all three subTasks should have started
            var result = _controller.GetUnit("marine");
            Assert.That(result.IsCompleted, Is.False);
            _db.VerifyAll();
            _webService.VerifyAll();

            //Nothing has finished yet. Complete tasks in any order
            var unit = new Unit();
            unitTcs.SetResult(unit);
            buildingTcs.SetResult("barracks");
            countersTcs.SetResult(new List<string>{"foo","bar"});
            
            //Nw we should be finished.
            Assert.That(result.IsCompleted);
            Assert.That(result.Result, Is.SameAs(unit));
            Assert.That(unit.BuiltFrom, Is.EqualTo("barracks"));

        }
    }
}
