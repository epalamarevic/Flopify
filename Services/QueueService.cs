using Contracts;
using Data;
using Models;
using Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class QueueService : IQueueService
    {
        private readonly Guid _userId;
        public QueueService(Guid userId)
        {
            _userId = userId;
        }

        //Create a Queue
        public void CreateQueue()
        {
            var entity = new Queue()
            {
                UserId = _userId,
                Tracks = new List<Track>()
            };

            using (var ctx = new ApplicationDbContext())
            {
                var check = ctx.Queues.Where(e => e.UserId == _userId).ToList();
                if (check.Count() == 0)
                {
                    ctx.Queues.Add(entity);
                    ctx.SaveChanges();
                }
            }
        }

        //Add track to Queue
        public void AddTrackToQueue(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var track = ctx.Tracks.Single(e => e.TrackId == trackId && e.IsActive == true);
                ctx.Queues.Single(q => q.UserId == _userId).Tracks.Add(track);
                ctx.SaveChanges();
            }
        }

        //Add tracks from album to queue
        public void AddAlbumToQueue(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tracks = ctx.Tracks.Where(e => e.AlbumId == albumId && e.IsActive == true).ToList();
                var queue = ctx.Queues.Single(q => q.UserId == _userId);
                foreach (Track track in tracks)
                {
                    if(!queue.Tracks.Contains(track))
                    {
                        queue.Tracks.Add(track);
                    }
                }
                ctx.SaveChanges();
            }
        }

        //Add tracks from band to queue
        public void AddBandToQueue(int bandId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tracks = ctx.Tracks.Where(e => e.BandId == bandId && e.IsActive == true).ToList();
                var queue = ctx.Queues.Single(q => q.UserId == _userId);
                foreach (Track track in tracks)
                    queue.Tracks.Add(track);

                ctx.SaveChanges();
            }
        }

        //Get all tracks in queue
        public IEnumerable<TrackListModel> GetAllFromQueue()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Queues
                    .Single(e => e.UserId == _userId)
                    .Tracks
                    .Select
                        (q => new TrackListModel()
                        {
                            TrackId = q.TrackId,
                            Title = q.Title,
                            PlayTime = q.PlayTime
                        });

                return query.ToArray();
            }
        }

        // Method to Create a new Playlist from the current Queue
        public void CreatePlaylistFromQueue(PlaylistCreateModel model)
        {
            var entity = new Playlist()
            {
                Title = model.Title,
                Tracks = new List<Track>()
            };

            using (var ctx = new ApplicationDbContext())
            {
                var queueTracks = ctx.Queues.Single(e => e.UserId == _userId).Tracks;
                foreach (Track track in queueTracks)
                {
                    entity.Tracks.Add(track);
                }
                ctx.Playlists.Add(entity);
                ctx.SaveChanges();
            }
        }

        //Add tracks to playlist from queue
        public void AddToPlayListFromQueue(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queueTracks = ctx.Queues.Single(e => e.UserId == _userId).Tracks;
                var playlist = ctx.Playlists.Single(e => e.IsActive == true && e.PlaylistId == playlistId);
                foreach (Track track in queueTracks)
                {
                    ctx.Playlists.Single(e => e.IsActive == true && e.PlaylistId == playlistId).Tracks.Add(track);
                }
                ctx.SaveChanges();
            }
        }

        // Method to remove a Track from the Queue
        public void DeleteTrackFromQueue(int trackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var track = ctx.Queues.Single(e => e.UserId == _userId).Tracks.Single(t => t.TrackId == trackId);

                ctx.Queues.Single(e => e.UserId == _userId).Tracks.Remove(track);

                ctx.SaveChanges();
            }
        }

        //Clear out the queue
        public void ClearQueue()
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Queues.Single(e => e.UserId == _userId).Tracks.Clear();
                ctx.SaveChanges();
            }
        }
    }
}
