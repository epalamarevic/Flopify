using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Track
{
    public class TrackCreateModel
    {
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public int PlayTime { get; set; }
    }
}
