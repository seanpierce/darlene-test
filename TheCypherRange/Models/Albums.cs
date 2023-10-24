using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCypherRange.Models
{
    public class Albums
    {
        public int AlbumID { get; set; }
        public  required string AlbumName { get; set; }
        public int ReleaseYear { get; set; }    
        public string Artist { get; set;}   

        public double Price { get; set; }

        



        
            

    }
}
