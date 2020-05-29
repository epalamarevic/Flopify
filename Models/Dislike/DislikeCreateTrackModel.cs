using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dislike
{
    public class DislikeCreateTrackModel
    {
        public int BandId { get; set; }
        public int AlbumId { get; set; }
        public int TrackId { get; set; }
    }
}
