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
                    AlbumId = model.AlbumId,
                    PlayTime = model.PlayTime,
                    UserId = _userId
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
                        .Single(e => e.TrackId == trackId/* && e.UserId == _userId*/);
                // Uncomment the portion above to ensure that Tracks are only able to be deleted by the user that created them

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
                                    PlayTime = e.PlayTime
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
                        Title = entity.Title,
                        Dislikes = entity.Dislikes,
                        AlbumId = entity.AlbumId,
                        PlayTime = entity.PlayTime
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
                        .Single(e => e.TrackId == model.TrackId/* && e.UserId == _userId*/);
                // Uncomment the portion above to ensure that Tracks are only able to be edited by the user that created them

                entity.Title = model.UpdatedTitle;
                entity.PlayTime = model.PlayTime;

                ctx.SaveChanges();
            }
        }
    }
}
