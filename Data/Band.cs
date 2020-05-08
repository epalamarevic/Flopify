﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Members { get; set; }
    }
}