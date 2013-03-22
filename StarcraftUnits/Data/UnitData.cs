using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using StarcraftUnits.Models;

namespace StarcraftUnits.Data
{
    public interface IUnitData
    {
        Task<IList<UnitSummary>> GetAllUnits();
        Unit GetUnit(string name);
    }

    class UnitData : IUnitData
    {
        private const string ConnectionString = @"Data Source=D:\Units.sdf";

        public async Task<IList<UnitSummary>> GetAllUnits()
        {
            var list = new List<UnitSummary>();

            using (var connection = new SqlCeConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCeCommand("SELECT Name,Race FROM Units", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
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