using Contracts;
using Data;
using Models.Dislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DislikeService : IDislikeService
    {
        // Constructor to catch the User Id that is passed in through the Controller
        private readonly Guid _userId;
        public DislikeService(Guid userId)
        {
            _userId = userId;
        }

        // Method to Create a Dislike for a Track
        public void CreateTrackDislike(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var track = ctx.Tracks.Single(e => e.TrackId == trackId && e.IsActive == true);

                var entity = new Dislike()
                {
                    UserId = _userId,
                    BandId = track.BandId,
                    AlbumId = track.AlbumId,
                    TrackId = track.TrackId
                };

                //var check = CheckForDuplicateDislike(entity);
                //if (check == false)
                //{
                //    ctx.Dislikes.Add(entity);
                //    ctx.SaveChanges();
                //}
                // -Uncomment this block and comment the block below to ensure only one dislike can be made per item per user

                ctx.Dislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Method to Create a Dislike for an Album
        public void CreateAlbumDislike(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var album = ctx.Albums.Single(e => e.AlbumId == albumId && e.IsActive == true);

                var entity = new Dislike()
                {
                    UserId = _userId,
                    BandId = album.BandId,
                    AlbumId = album.AlbumId
                };

                //var check = CheckForDuplicateDislike(entity);
                //if (check == false)
                //{
                //    ctx.Dislikes.Add(entity);
                //    ctx.SaveChanges();
                //}
                // -Uncomment this block and comment the block below to ensure only one dislike can be made per item per user

                ctx.Dislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Method to Create a Dislike for a Band
        public void CreateBandDislike(int bandId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var band = ctx.Bands.Single(e => e.BandId == bandId && e.IsActive == true);

                var entity = new Dislike()
                {
                    UserId = _userId,
                    BandId = band.BandId
                };

                //var check = CheckForDuplicateDislike(entity);
                //if (check == false)
                //{
                //    ctx.Dislikes.Add(entity);
                //    ctx.SaveChanges();
                //}
                // -Uncomment this block and comment the block below to ensure only one dislike can be made per item per user

                ctx.Dislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Method to list all active Dislikes
        public IEnumerable<DislikeListModel> ListDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Dislikes.Where(e => e.IsActive == true).Select(e => new DislikeListModel { DislikeId = e.DislikeId, BandId = e.BandId, AlbumId = e.AlbumId, TrackId = e.TrackId });
                return query.ToArray();
            }
        }

        // Method to Delete a Dislike
        public void DeleteDislike(int dislikeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.Dislikes.Single(e => e.DislikeId == dislikeId && e.UserId == _userId);
                itemToDelete.IsActive = false;
                ctx.SaveChanges();
            }
        }

        // Helper method that checks to make sure the user has not already liked a certain item
        private bool CheckForDuplicateDislike(Dislike potentialNewDislike)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Dislikes.Where(e => e.UserId == _userId && e.TrackId == potentialNewDislike.TrackId && e.BandId == potentialNewDislike.BandId && e.AlbumId == potentialNewDislike.AlbumId && e.IsActive == true).ToList();
                if (query.Count > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
