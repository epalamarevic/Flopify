using Contracts;
using Data;
using Models.TrackDislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TrackDislikeService : IDislikeService
    {
        private readonly Guid _userId;
        public TrackDislikeService(Guid userId)
        {
            _userId = userId;
        }

        public void CreateDislike(TrackDislikeCreate model)
        {
            var entity = new TrackDislike()
            {
                TrackId = model.TrackId,
                UserId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.TrackDislikes.Where(e => e.UserId == _userId && e.TrackId == model.TrackId);
                if (query == null)
                {
                    ctx.TrackDislikes.Add(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public IEnumerable<TrackDislikeList> GetAllDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.TrackDislikes.Select(e => new TrackDislikeList { TrackDislikeId = e.TrackDislikeId, TrackId = e.TrackId });
                return request.ToArray();
            }
        }

        public void DeleteDislike(int trackDislikeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.TrackDislikes.Single(e => e.TrackDislikeId == trackDislikeId);
                ctx.TrackDislikes.Remove(itemToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
