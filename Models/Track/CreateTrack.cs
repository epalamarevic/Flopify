﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Track
{
    public class CreateTrack
    {
        public int TrackId { get; set; }
        public string Title { get; set; }
        public TimeSpan PlayTime { get; set; }

    }
}