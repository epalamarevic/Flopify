using Contracts;
using Data;
using Models.AlbumDislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AlbumDislikeService : IAlbumDislikeService
    {
        private readonly Guid _userId;
        public AlbumDislikeService(Guid userId)
        {
            _userId = userId;
        }

        public void CreateAlbumDislike(int albumId)
        {
            var entity = new AlbumDislike()
            {
                AlbumId = albumId,
                UserId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                //var query = ctx.AlbumDislikes.Where(e => e.UserId == _userId && e.AlbumId == albumId).ToList();
                //if (query.Count == 0)
                //{
                //    ctx.AlbumDislikes.Add(entity);
                //    ctx.SaveChanges();
                //}
                ctx.AlbumDislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<AlbumDislikeList> GetAllAlbumDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.AlbumDislikes.Select(e => new AlbumDislikeList { AlbumDislikeId = e.AlbumDislikeId, AlbumId = e.AlbumId });
                return request.ToArray();
            }
        }

        public void DeleteAlbumDislike(int albumDislikeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.AlbumDislikes.Single(e => e.AlbumDislikeId == albumDislikeId);
                ctx.AlbumDislikes.Remove(itemToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
