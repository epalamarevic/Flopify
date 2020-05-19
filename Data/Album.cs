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
                    var playTimeList = ctx.Tracks.Where(e => e.AlbumId == AlbumId).Select(e => e.PlayTime).ToList();
                    var sum = playTimeList.Sum();
                    return sum;
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

        public int NumberOfTracks
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var tracks = ctx.Tracks.Where(e => e.AlbumId == AlbumId).Count();
                    return tracks;
                }
            }
        }

        public int Dislikes
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var dislikes = ctx.Dislikes.Where(e => e.AlbumId == AlbumId && e.IsActive == true).Count();
                    return dislikes;
                }
            }
        }

        public DateTime DateReleased { get; set; }

        [ForeignKey("Band")]
        public int BandId { get; set; }
        public virtual Band Band { get; set; }
    }
}
