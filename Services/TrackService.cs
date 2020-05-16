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
        // Checking UserId to set later for each service
        private readonly Guid _userId;
        public TrackService(Guid userId)
        {
            _userId = userId;
        }

        // Service to Create a Track
        public void CreateTrack(CreateTrack model)
        {
            var entity =
                new Track()
                {
                    Title = model.Title,
                    //PlayTimeTicks = TimeSpan.FromTicks(model.PlayTime.Ticks).Ticks,
                    AlbumId = model.AlbumId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tracks.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Service to Delete a Track by TrackId
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

        // Service to return each Track in an IEnumerable List
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
                                    //PlayTime = TimeSpan.FromTicks(e.PlayTimeTicks)
                                }
                        );

                return query.ToArray();
            }
        }

        // Service to return details of a Track, selected by TrackId
        public TrackDetail GetTrackById(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tracks
                        .Single(e => e.TrackId == trackId);
                return
                    new TrackDetail
                    {
                        TrackId = entity.TrackId,
                        AlbumId = entity.AlbumId,
                        Title = entity.Title,
                       // PlayTime = TimeSpan.FromTicks(entity.PlayTimeTicks),
                        Dislikes = entity.Dislikes
                    };
            }
        }

        // Service to update a Track by the TrackId given in the body
        public void UpdateTrack(UpdateTrack model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tracks
                        .Single(e => e.TrackId == model.TrackId);

                entity.Title = model.UpdatedTitle;

                //entity.PlayTimeTicks = TimeSpan.FromTicks(model.UpdatedPlayTime.Ticks).Ticks;

                ctx.SaveChanges();
            }
        }
    }
}
