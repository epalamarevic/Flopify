using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    [RoutePrefix("Flopify")]
    public class PlaylistController : ApiController
    {
        //post a playlist
        [HttpPost]
        [Route("Playlist")]
        public IHttpActionResult PostPlaylist(CreatePlaylist playlist)
        {
            PlaylistService playlistService = CreatePlaylistService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            playlistService.CreatePlaylist(playlist);

            return Ok();
        }

        

        [HttpGet]
        [Route("Playlist")]
        public IHttpActionResult GetPlaylist()
        {
            PlaylistService playlistService = CreatePlaylistService();

            var playlists = playlistService.GetAllPlaylists();

            return Ok(playlists);
        }

        //[HttpGet]
        //[Route("Playlist/{id}")]
        //public IHttpActionResult GetPlaylistbyID(int id)
        //{
        //    PlaylistService playlistService = CreatePlaylistService();

        //    var playlist = playlistService.GetPlaylistById(id);

        //    return Ok(playlist);
        //}

        //[HttpDelete]
        //[Route("Playlist/{id}")]
        //public IHttpActionResult DeletePlaylistById(int id)
        //{
        //    PlaylistService playlistService = CreatePlaylistService();

        //    playlistService.DeletePlaylist(id);

        //    return Ok();
        //}


        private PlaylistService CreatePlaylistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playlistService = new PlaylistService(userId);
            return playlistService;
        }
    }
}
