using System.Collections.Generic;
using System.Web.Http;
using StarcraftUnits.Data;
using StarcraftUnits.Models;

namespace StarcraftUnits.Controllers
{
    public class UnitsController : ApiController
    {
        private readonly IUnitData _db;

        public UnitsController(IUnitData db)
        {
            _db = db;
        }

        public UnitsController():this(new UnitData()){}

        public IList<UnitSummary> GetAllUnits()
        {
            return _db.GetAllUnits();
        }
    }
}
