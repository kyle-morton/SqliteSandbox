using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SqliteEFDemo
{
    public class SqlLiteConnService
    {
        private string _connectionString => ConfigurationManager.AppSettings["connectionString"];

        public void GetData()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM employees; ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var EmployeeId = reader["EmployeeId"].ToString();
                                var LastName = reader["LastName"].ToString();
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("Ex: " + e);
            }
        }

    }
}
