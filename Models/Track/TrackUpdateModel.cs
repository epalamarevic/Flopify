using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Track
{
    public class TrackUpdateModel
    {
        public int TrackId { get; set; }
        public string UpdatedTitle { get; set; }
        public int PlayTime { get; set; }
    }
}
