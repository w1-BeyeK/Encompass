using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Datalayer
{
    public static class Database
    {
        private static readonly string conn = "Server=mssql.fhict.local;Database=dbi409368_pt;User Id=dbi409368_pt;Password=encompassPT12;";

        public static DataTable ExecSelect(string query)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(conn);
            ds.Clear();
            using(SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection))
            {
                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        public static bool ExecOverig(string query)
        {
            bool success = true;

            SqlConnection sqlConnection = new SqlConnection(conn);
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }


        // Get last inserted ID
        public static int LastInsertedId()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("select LAST_INSERT_ID()", sqlConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(int.TryParse(reader[0].ToString(), out int lastId))
                    {
                        return lastId;
                    } else
                    {
                        throw new IndexOutOfRangeException("Last inserted id not found.");
                    }
                }
            }
        }
    }
}
