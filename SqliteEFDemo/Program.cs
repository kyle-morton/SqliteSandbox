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
            new SqlLiteConnService().GetData();
            Console.WriteLine("After Data...");
            Console.ReadLine();
        }
    }
}
