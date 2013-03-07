using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using StarcraftUnits.Models;

namespace StarcraftUnits.Data
{
    class UnitData : IUnitData
    {



        public IList<UnitSummary> GetAllUnits()
        {
            var list = new List<UnitSummary>();

            using (var connection = new SqlCeConnection(@"Data Source=D:\Units.sdf"))
            {
                connection.Open();
                using (var command = new SqlCeCommand("SELECT Name,Race FROM Units", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var summary = new UnitSummary
                        {
                            Name = reader.GetString(0),
                            Race = reader.GetString(1)
                        };
                        list.Add(summary);
                    }
                }
            }
            return list;
        }
    }
}