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
        private readonly Guid _userId;
        public PlaylistService(Guid userId)
        {
            _userId = userId;
        }

        //Create a Playlist
        public void CreatePlaylist(CreatePlaylist model)
        {
            var entity =
                new Playlist()
                {
                    Title = model.Title,
                    Tracks = new List<Track>()
                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Playlists.Add(entity);
                ctx.SaveChanges();
            }
        }

        //ADD TRACKS TO PLAYLIST
        public void AddTrackToPlaylist(TrackAddModel ids)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var track = ctx.Tracks.Single(e => e.TrackId == ids.TrackId && e.IsActive == true);
                var playlist = ctx.Playlists.Single(e => e.PlaylistId == ids.PlaylistId && e.IsActive == true);
                playlist.Tracks.Add(track);
                ctx.SaveChanges();
            }
        }

        ////Get list of Playlist
        public IEnumerable<ListPlaylistModel> GetAllPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Playlists
                    .Where(e => e.IsActive == true)
                    .Select(
                        e => new ListPlaylistModel
                        {
                            Title = e.Title,
                            PlaylistId = e.PlaylistId,
                            NumberOfTracks = ctx.Playlists.Where(x => x.IsActive == true && x.PlaylistId == e.PlaylistId).Select(x => x.Tracks).Count()
                        });
                
                return query.ToArray();
            }
        }

        
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