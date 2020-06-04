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
        public Guid UserId { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
        
        public bool IsActive { get; set; } = true;

        //public int NumberOfTracks
        //{
        //    get
        //    {
        //        using (var ctx = new ApplicationDbContext())
        //        {
        //            var Track= ctx.Playlists.Where(e => e.Tracks == Tracks && e.IsActive == true).Count();
        //            return Track;
        //        }
        //    }
        //}
    }

}