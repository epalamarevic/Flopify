using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ListPlaylistModel
    {
        public int PlaylistId { get; set; }
       
        public string Title { get; set; }
        public int NumberOfPlaylistTracks { get; set; }

        public int TrackId { get; set; }



    }
}
