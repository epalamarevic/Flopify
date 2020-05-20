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
        private readonly Guid _userId;
        public DislikeService(Guid userId)
        {
            _userId = userId;
        }

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
                ctx.Dislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

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
                ctx.Dislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void CreateBandDislike(CreateBandDislikeModel dislike)
        {
            var entity = new Dislike()
            {
                UserId = _userId,
                BandId = dislike.BandId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<ListDislikeModel> ListDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Dislikes.Where(e => e.IsActive == true).Select(e => new ListDislikeModel { DislikeId = e.DislikeId, BandId = e.BandId, AlbumId = e.AlbumId, TrackId = e.TrackId });
                return query.ToArray();
            }
        }

        public void DeleteDislike(DeleteDislikeModel dislike)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.Dislikes.Single(e => e.DislikeId == dislike.DislikeId && e.UserId == _userId);
                itemToDelete.IsActive = false;
                ctx.SaveChanges();
            }
        }
    }
}
