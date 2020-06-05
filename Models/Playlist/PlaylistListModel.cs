using Data;
using Models.Track;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlaylistListModel
    {
        public int PlaylistId { get; set; }
        public string Title { get; set; }
        public int NumberOfTracks { get; set; }
    }
}
