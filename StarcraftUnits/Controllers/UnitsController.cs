using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using StarcraftUnits.Data;
using StarcraftUnits.Models;

namespace StarcraftUnits.Controllers
{
    public class UnitsController : ApiController
    {
        private readonly IUnitData _db;
        private readonly IWebServiceClient _client;

        public UnitsController(IUnitData db, IWebServiceClient client)
        {
            _client = client;
            _db = db;
        }

        public UnitsController():this(new UnitData(), new WebServiceClient()){}

        // GET /units
        public Task<IList<UnitSummary>> GetAllUnits()
        {
            return _db.GetAllUnits();
        }

        // GET /units/Marine
        public Task<Unit> GetUnit(string id)
        {
            return AggregateUnit(id);
        }

        public async Task<Unit> AggregateUnit(string name)
        {
            var unitTask = _db.GetUnit(name);
            var countersTask = _client.GetCountersFor(name);
            var builtFromTask = _client.BuiltFrom(name);

            await Task.WhenAll(unitTask, countersTask, builtFromTask);
            var unit = unitTask.Result;
            unit.BuiltFrom = builtFromTask.Result;
            unit.Counters = countersTask.Result;
            return unit;
        }
    }
}
