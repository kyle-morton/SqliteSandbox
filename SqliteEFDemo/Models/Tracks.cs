using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteEFDemo.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        //public object TrackId { get; set; }
        //public object Name { get; set; }
        //public object AlbumId { get; set; }
        //public object MediaTypeId { get; set; }
        //public object GenreId { get; set; }
        //public object Composer { get; set; }
        //public object Milliseconds { get; set; }
        //public object Bytes { get; set; }
        //public object UnitPrice { get; set; }

    }
}
