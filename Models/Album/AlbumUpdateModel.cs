﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Album
{
    public class AlbumUpdateModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }
    }
}
