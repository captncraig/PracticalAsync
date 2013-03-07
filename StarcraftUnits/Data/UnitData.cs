using System.Collections.Generic;
using System.Data.SqlServerCe;
using StarcraftUnits.Models;
using Dapper;
using System.Linq;

namespace StarcraftUnits.Data
{
    class UnitData : IUnitData
    {
        private const string ConnectionString = @"Data Source=D:\Units.sdf";

        public IList<UnitSummary> GetAllUnits()
        {
            var list = new List<UnitSummary>();

            using (var connection = new SqlCeConnection(ConnectionString))
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

        public Unit GetUnit(string name)
        {
            using (var connection = new SqlCeConnection(ConnectionString))
            {
                connection.Open();
                var results = connection.Query<Unit>("SELECT * FROM Units Where Name = @Name", new {Name = name});
                return results.SingleOrDefault();
            }
        }
    }
}