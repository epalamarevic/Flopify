using Contracts;
using Data;
using Models;
using Models.Playlist;
using Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PlaylistService : IPlaylistService
    {
        // Constructor to catch the User Id that is passed in through the Controller
        private readonly Guid _userId;
        public PlaylistService(Guid userId)
        {
            _userId = userId;
        }

        // Method to Create a Playlist
        public void CreatePlaylist(PlaylistCreateModel model)
        {
            var entity =
                new Playlist()
                {
                    Title = model.Title,
                    UserId = _userId,
                    Tracks = new List<Track>()
                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Playlists.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Method to add Tracks to a Playlist
        public void AddTrackToPlaylist(PlaylistTrackAddModel ids)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var track = ctx.Tracks.Single(e => e.TrackId == ids.TrackId && e.IsActive == true);
                var playlist = ctx.Playlists.Single(e => e.PlaylistId == ids.PlaylistId && e.IsActive == true);
                playlist.Tracks.Add(track);
                ctx.SaveChanges();
            }
        }

        // Method to Get a list of Playlists
        public IEnumerable<PlaylistListModel> GetAllPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Playlists
                    .Where(e => e.IsActive == true)
                    .Select(
                        e => new PlaylistListModel
                        {
                            Title = e.Title,
                            PlaylistId = e.PlaylistId,
                            NumberOfTracks = e.Tracks.Count()
                        }) ;
                
                return query.ToArray();
            }
        }

        // Method to Get the contents of a Playlist
        public IEnumerable<TrackListModel> GetPlaylistContent(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Playlists.Single(e => e.PlaylistId == playlistId).Tracks
                    .Select(p => new TrackListModel()
                    {
                        TrackId = p.TrackId,
                        Title = p.Title,
                        PlayTime = p.PlayTime
                    });

                return query;
            }
        }

        // Method to remove a Track from a Playlist
        public void DeleteTrack(PlaylistTrackDeleteModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var track =
                    ctx
                    .Playlists
                    .Single(e => e.PlaylistId == model.PlaylistId && e.IsActive == true)
                    .Tracks
                    .Single(t => t.TrackId == model.TrackId);

                ctx
                    .Playlists
                    .Single(e => e.PlaylistId == model.PlaylistId && e.IsActive == true)
                    .Tracks
                    .Remove(track);

                ctx.SaveChanges();
            }
        }
       
        // Method to Delete a Playlist
        public void DeletePlaylist(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Playlists
                        .Single(e => e.PlaylistId == playlistId/* && e.UserId == _userId*/);
                // Uncomment the portion above to ensure that Playlists are only able to be deleted by the user that created them

                entity.IsActive = false;

                ctx.SaveChanges();
            }
        }

    }
}