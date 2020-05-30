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
        // Constructor to catch the User Id that is passed in through the Controller
        private readonly Guid _userId;
        public TrackService(Guid userId)
        {
            _userId = userId;
        }

        // Method to Create a Track
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

        // Method to List all Tracks
        public IEnumerable<TrackList> GetAllTracks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tracks
                        .Where(e => e.IsActive == true)
                        .Select(
                            e =>
                                new TrackList
                                {
                                    TrackId = e.TrackId,
                                    Title = e.Title,
                                    PlayTime = e.PlayTime
                                }
                        );

                return query.ToArray();
            }
        }

        // Method to Get a specific Track by the Track Id
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

        // Service to Update a Track by the Track Id
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

        // Service to Delete a Track by the Track Id
        public void DeleteTrack(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tracks
                        .Single(e => e.TrackId == trackId/* && e.UserId == _userId*/);
                // Uncomment the portion above to ensure that Tracks are only able to be deleted by the user that created them

                entity.IsActive = false;

                ctx.SaveChanges();
            }
        }
    }
        
}
