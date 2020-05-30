using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public string Title {get; set;}

        public virtual ICollection<Track> Tracks { get; set; }

        public int TrackId { get; set; }
        public virtual Track Track { get; set; }
        public bool IsActive { get; set; } = true;

        public int NumberOfPlaylistTracks
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var tracks = ctx.Tracks.Where(e => e.TrackId == TrackId && e.IsActive == true).Count();
                    return tracks;
                }
            }
        }
    }

}