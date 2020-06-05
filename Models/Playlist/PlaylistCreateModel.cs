using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlaylistCreateModel
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
    }
}
