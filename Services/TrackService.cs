using Contracts;
using Data;
using Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TrackService : ITrackServices
    {
        private readonly Guid _userId;
        public TrackService(Guid userId)
        {
            _userId = userId;
        }

        public void CreateTrack(CreateTrack model)
        {
            var entity =
                new Track()
                {
                    Title = model.Title,
                    PlayTime = model.PlayTime,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tracks.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void DeleteTrack(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tracks
                        .Single(e => e.TrackId == trackId);

                ctx.Tracks.Remove(entity);

                ctx.SaveChanges();
            }
        }

        public IEnumerable<TrackList> GetAllTracks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tracks
                        .Select(
                            e =>
                                new TrackList
                                {
                                    TrackId= e.TrackId,
                                    Title = e.Title,
                                    PlayTime = e.PlayTime,
                                }
                        );

                return query.ToArray();
            }
        }

        public TrackDetail GetTrackById(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // int dislikes = ctx.TrackDislikes.Where(e => e.TrackId == trackId).Count();

                var entity =
                    ctx
                        .Tracks
                        .Single(e => e.TrackId == trackId);
                return
                    new TrackDetail
                    {
                        TrackId = entity.TrackId,
                        Title = entity.Title,
                        PlayTime = entity.PlayTime,
                        Dislikes = entity.Dislikes
                    };
            }
        }

        public void UpdateTrack(UpdateTrack model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tracks
                        .Single(e => e.TrackId == model.TrackId);

                entity.Title = model.UpdatedTitle;
                entity.PlayTime = model.UpdatedPlayTime;

                ctx.SaveChanges();
            }
        }
    }
}
