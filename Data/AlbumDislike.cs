using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AlbumDislike
    {
        [Key]
        public int AlbumDislikeId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
