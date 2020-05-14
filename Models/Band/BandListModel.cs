using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Band
{
    public class BandListModel
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int NumberOfAlbums { get; set; }
    }
}
