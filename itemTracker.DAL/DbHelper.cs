using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itemTracker.DAL
{
    public static class DbHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
