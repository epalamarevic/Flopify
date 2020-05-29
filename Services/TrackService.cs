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
        public void CreateTrack(TrackCreateModel model)
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
        public IEnumerable<TrackListModel> GetAllTracks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tracks
                        .Where(e => e.IsActive == true)
                        .Select(
                            e =>
                                new TrackListModel
                                {
                                    TrackId= e.TrackId,
                                    Title = e.Title,
                                    PlayTime = e.PlayTime
                                }
                        );

                return query.ToArray();
            }
        }

        // Method to List all Tracks, ordered by most Disliked
        public IEnumerable<TrackListByDislikesModel> GetAllTracksByDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tracks
                        .Where(e => e.IsActive == true)
                        .Select(
                            e =>
                                new TrackListByDislikesModel
                                {
                                    TrackId = e.TrackId,
                                    Title = e.Title,
                                    PlayTime = e.PlayTime,
                                    Dislikes = ctx.Dislikes.Where(x => x.IsActive == true && x.TrackId == e.TrackId).Count()
                                }
                        ).OrderByDescending(d => d.Dislikes);

                return query.ToArray();
            }
        }

        // Method to Get a specific Track by the Track Id
        public TrackDetailModel GetTrackById(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tracks
                        .Single(e => e.TrackId == trackId);
                return
                    new TrackDetailModel
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
        public void UpdateTrack(TrackUpdateModel model)
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
