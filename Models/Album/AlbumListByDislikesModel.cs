using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Album
{
    public class AlbumListByDislikesModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int BandId { get; set; }
        public int Dislikes { get; set; }
    }
}
