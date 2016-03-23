using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Login
{
    public class Conex
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AUSACnn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
     
    }
}