using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SqliteEFDemo.Models;
using System.Data;
using Dapper;

namespace SqliteEFDemo
{
    public class SqlLiteConnService
    {
        private string _connectionString => ConfigurationManager.AppSettings["connectionString"];

        public List<Track> GetData()
        {
            var list = new List<Track>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    //string sql = "SELECT * FROM tracks; ";
                    string sql = "SELECT TrackId, Name, AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice FROM tracks;";

                    var results = conn.Query<Track>(sql).ToList();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                var records = reader.Cast<IDataRecord>().ToList();
                                list = MappingUtil.ToTracks(records);
                            }
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var EmployeeId = reader["TrackId"].ToString();
                                    var LastName = reader["Name"].ToString();
                                }
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

            return list;
        }



    }
}
