using Contracts;
using Data;
using Models.TrackDislike;
using System;
using System.Collections.Generic;
using System.Linq;
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
                TrackId = model.TrackId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TrackDislikes.Add(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<TrackDislikeList> GetAllDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.TrackDislikes.Select(e => new TrackDislikeList { TrackId = e.TrackId });
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
