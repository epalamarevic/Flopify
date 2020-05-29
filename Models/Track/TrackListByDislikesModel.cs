using Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Track
{
    public class TrackListByDislikesModel
    {
        public int TrackId { get; set; }
        public string Title { get; set; }
        public int PlayTime { get; set; }
        public int Dislikes { get; set; }
    }
}
