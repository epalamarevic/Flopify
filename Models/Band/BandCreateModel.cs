using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Band
{
    public class BandCreateModel
    {
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Members { get; set; }
    }
}
