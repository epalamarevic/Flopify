using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Track
{
    public class TrackDetail
    {
        public int TrackId { get; set; }
        public string Title { get; set; }
       // public TimeSpan PlayTime { get; set; }

        public int Dislikes { get; set; }
        public int AlbumId { get; set; }
    }
}
