using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Dislike
    {
        [Key]
        public int DislikeId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("Band")]
        public int BandId { get; set; }
        public virtual Band Band { get; set; }

        [ForeignKey("Album")]
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [ForeignKey("Track")]
        public int? TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}
