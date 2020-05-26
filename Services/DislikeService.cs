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
        public void CreateTrackDislike(CreateTrackDislikeModel dislike)
        {
            var entity = new Dislike()
            {
                UserId = _userId,
                BandId = dislike.BandId,
                AlbumId = dislike.AlbumId,
                TrackId = dislike.TrackId
            };

            using (var ctx = new ApplicationDbContext())
            {
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
        public void CreateAlbumDislike(CreateAlbumDislikeModel dislike)
        {
            var entity = new Dislike()
            {
                UserId = _userId,
                BandId = dislike.BandId,
                AlbumId = dislike.AlbumId
            };

            using (var ctx = new ApplicationDbContext())
            {
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
        public void CreateBandDislike(CreateBandDislikeModel dislike)
        {
            var entity = new Dislike()
            {
                UserId = _userId,
                BandId = dislike.BandId
            };

            using (var ctx = new ApplicationDbContext())
            {
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
        public IEnumerable<ListDislikeModel> ListDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Dislikes.Where(e => e.IsActive == true).Select(e => new ListDislikeModel { DislikeId = e.DislikeId, BandId = e.BandId, AlbumId = e.AlbumId, TrackId = e.TrackId });
                return query.ToArray();
            }
        }

        // Method to Delete a Dislike
        public void DeleteDislike(DeleteDislikeModel dislike)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.Dislikes.Single(e => e.DislikeId == dislike.DislikeId && e.UserId == _userId);
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
