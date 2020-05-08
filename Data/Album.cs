using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public TimeSpan PlayTime { get; set; }
        public int NumberOfSongs { get; set; }

        //[ForeignKey("Band")]
        //public int BandId { get; set; }
    }
}
