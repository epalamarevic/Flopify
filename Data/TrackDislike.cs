﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TrackDislike
    {
        [Key]
        public int TrackDislikeId {get; set;}
        public Guid UserId { get; set; }

        [ForeignKey("Track")]
        public int TrackId{ get; set; }
        public virtual Track Track { get; set; }
    }
}
