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

        #region CONN STRING

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        #endregion

        #region GET RECORD(S)

        public T GetRecord<T>(string query)
        {
            T result = default(T);
            try
            {

                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    result = conn.Query<T>(query).SingleOrDefault();
                    conn.Close();
                }

            }
            catch (SQLiteException e)
            {
                Console.WriteLine("Ex: " + e);
            }

            return result;
        }

        public List<T> GetRecords<T>(string query)
        {
            var list = new List<T>();
            try {

                using (SQLiteConnection conn = GetConnection()) { 
                    conn.Open();
                    list = conn.Query<T>(query).ToList();
                    conn.Close();
                }

            } catch (SQLiteException e) {
                Console.WriteLine("Ex: " + e);
            }

            return list;
        }

        #endregion

        public List<Track> GetTracks()
        {
            return GetRecords<Track>("SELECT * FROM tracks;");
        }

        public Track GetTrack(int id)
        {
            return GetRecord<Track>($"SELECT * FROM tracks WHERE TrackId = {id};");
        }

    }
}
