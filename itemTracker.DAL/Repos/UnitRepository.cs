using itemTracker.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itemTracker.DAL.Repos
{
    public class UnitRepository
    {
        public List<Unit> GetAllUnits()
        {
            var units = new List<Unit>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Units", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    units.Add(new Unit
                    {
                        UnitID = (int)reader["UnitID"],
                        UnitName = reader["UnitName"].ToString()
                    });
                }
            }

            return units;
        }
    }
}
