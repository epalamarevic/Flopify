using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        public string Title { get; set; }
        public int PlayTime { get; set; }
        public int Dislikes
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var dislikes = ctx.Dislikes.Where(e => e.TrackId == TrackId && e.IsActive == true).Count();
                    return dislikes;
                }
            }
        }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [ForeignKey("Band")]
        public int BandId { get; set; }
        public virtual Band Band { get; set; }

        public Guid UserId { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Queue> Queues { get; set; }
    }

}

