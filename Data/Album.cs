using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }

        public int TotalPlaytime
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var Sum = ctx.Tracks.Where(e => e.AlbumId == AlbumId).Select(e => e.PlayTime).Sum();
                    return Sum;
                }
            }
        }



//public long PlayTimeTicks
//{
//    get
//    {
//        using (var ctx = new ApplicationDbContext())
//        {

//            var childTracksPlayTime = ctx.Tracks.Where(e => e.AlbumId == AlbumId).Select(e => e.PlayTimeTicks).ToList();
//            long playTime = 0;
//            for (int i = 0; i < childTracksPlayTime.Count(); i++)
//            {
//                playTime += childTracksPlayTime[i];
//            }
//            return playTime;
//        }
//    }
//    set { PlayTimeTicks = value; }
//}

        private int _numberOfTracks;
        public int NumberOfTracks
        {
            get
            {
                return _numberOfTracks;
            }
            set
            {
                using (var ctx = new ApplicationDbContext())
                {
                    _numberOfTracks = ctx.Tracks.Where(e => e.AlbumId == AlbumId).Count();
                }
            }
        }

        public DateTime DateReleased { get; set; }

        [ForeignKey("Band")]
        public int BandId { get; set; }
        public virtual Band Band { get; set; }
    }
}
