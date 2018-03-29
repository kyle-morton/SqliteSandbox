using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteEFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tracks = new SqlLiteConnService().GetTracks();
            var track = new SqlLiteConnService().GetTrack(691);
            Console.WriteLine("After Data...");
            Console.ReadLine();
        }
    }
}
