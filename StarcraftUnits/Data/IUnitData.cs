using System.Collections.Generic;
using StarcraftUnits.Models;

namespace StarcraftUnits.Data
{
    public interface IUnitData
    {
        IList<UnitSummary> GetAllUnits();
    }
}