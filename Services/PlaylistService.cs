using Contracts;
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    

        };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(entity);
                ctx.SaveChanges();
            }
        }

        ////Get list of Playlist
      public IEnumerable<ListPlaylistModel> GetAllPlaylists()
     {
        using (var ctx = new ApplicationDbContext())
            {
            var request = ctx.Playlists.Where(e => e.IsActive == true).Select(e => new ListPlaylistModel { Title = e.Title, PlaylistId = e.PlaylistId, });

                return request.ToArray();
            }
    }


        //// Get Playlist by ID
        //public ListPlaylistModel GetPlaylistById(int playlistId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx.Playlists.Single(e => e.PlaylistId == playlistId);

        //        return new ListPlaylistModel
        //        {
                    
        //            Title = entity.Title,
                    
        //        };
        //    }
        //}


        ////Delete a Playlist
        //public void DeletePlaylist(int playlistId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx.Playlists.Single(e => e.PlaylistId == playlistId);
                
        //        entity.IsActive = false;

        //        ctx.SaveChanges();
        //    }
        //}


       
    }
}
