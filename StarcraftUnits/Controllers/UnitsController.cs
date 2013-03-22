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
            var unit = await _db.GetUnit(name);
            var counters = await _client.GetCountersFor(name);
            unit.Counters = counters;
            var builtFrom = await _client.BuiltFrom(name);
            unit.BuiltFrom = builtFrom;
            return unit;
        }
    }
}
