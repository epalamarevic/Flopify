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
        public TimeSpan PlayTime { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        //[ForeignKey("Band")]
        //public int BandId { get; set; }

        public int Dislikes { get; set; }
    }
}
