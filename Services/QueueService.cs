﻿using Contracts;
using Data;
using Models;
using Models.Queue;
using Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateQueue()
        {
            var entity = new Queue()
            {
                UserId = _userId,
                Tracks = new List<Track>()
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Queues.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void AddTrackToQueue(QueueUpdateAddTrackModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var track = ctx.Tracks.Single(e => e.TrackId == model.TrackId && e.IsActive == true);
                var queue = ctx.Queues.Single(q => q.UserId == _userId);

                queue.Tracks.Add(track);
                ctx.SaveChanges();
            }
        }

        public void AddAlbumToQueue(QueueUpdateAddAlbumModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tracks = ctx.Tracks.Where(e => e.AlbumId == model.AlbumId && e.IsActive == true);
                var queue = ctx.Queues.Single(q => q.UserId == _userId);

                foreach (Track track in tracks)
                {
                    queue.Tracks.Add(track);
                }

                ctx.SaveChanges();
            }
        }

        public void AddBandToQueue(QueueUpdateAddBandModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tracks = ctx.Tracks.Where(e => e.BandId == model.BandId && e.IsActive == true);
                var queue = ctx.Queues.Single(q => q.UserId == _userId);

                foreach (Track track in tracks)
                {
                    queue.Tracks.Add(track);
                }

                ctx.SaveChanges();
            }
        }

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

                return query;
            }
        }

        public void CreatePlaylistFromQueue(CreatePlaylist model)
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

        public void AddToPlayListFromQueue(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {

            }
        }

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
