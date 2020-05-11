using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Album
{
    public class AlbumCreate
    {
        public string Title { get; set; }
        public TimeSpan PlayTime { get; set; }
        public int NumberOfTracks { get; set; }
        public DateTime DateReleased { get; set; }

        public int BandId { get; set; }
    }
}
