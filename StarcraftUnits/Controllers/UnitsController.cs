﻿using System.Collections.Generic;
using System.Web.Http;
using StarcraftUnits.Data;
using StarcraftUnits.Models;

namespace StarcraftUnits.Controllers
{
    public class UnitsController : ApiController
    {
        private readonly IUnitData _db;
        private IWebServiceClient _client;

        public UnitsController(IUnitData db, IWebServiceClient client)
        {
            _client = client;
            _db = db;
        }

        public UnitsController():this(new UnitData(), new WebServiceClient()){}

        // /units
        public IList<UnitSummary> GetAllUnits()
        {
            return _db.GetAllUnits();
        }

        // /units/Marine
        public Unit GetUnit(string id)
        {
            return AggregateUnit(id);
        }

        public Unit AggregateUnit(string name)
        {
            var unit = _db.GetUnit(name);
            var counters = _client.GetCountersFor(name);
            unit.Counters = counters;
            return unit;
        }
    }
}
