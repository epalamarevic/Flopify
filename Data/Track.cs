﻿using System;
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
        public long PlayTimeTicks { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public int Dislikes
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query = ctx.TrackDislikes.Where(e => e.TrackId == TrackId).Count();
                    return query;
                }
            }
        }

    }
}
