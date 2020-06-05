using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Band
{
    public class BandUpdateModel
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Members { get; set; }
    }
}
