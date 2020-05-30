using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Queue
{
    public class QueueUpdateAddTrackModel
    {
        public int TrackId { get; set; }
        public bool ReplaceAll { get; set; }
        public bool PlayNext { get; set; }
    }
}
