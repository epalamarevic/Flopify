using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Queue
    {
        [Key]
        public int QueueId { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
