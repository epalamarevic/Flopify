using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Band
{
    public class BandDetailModel
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Members { get; set; }
        public int NumberOfAlbums { get; set; }
        public int Dislikes { get; set; }
    }
}
