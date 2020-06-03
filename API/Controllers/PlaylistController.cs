using Contracts;
using Microsoft.AspNet.Identity;
using Models;
using Models.Playlist;
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
        /// <summary>
        /// Create a Playlist
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Post a Track to Playlist
        /// </summary>
        /// <param name="trackAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Playlist/PostTrackToPlaylist")]
        public IHttpActionResult PostTrackToPlaylist(TrackAddModel trackAdd)
        {
            PlaylistService playlistService = CreatePlaylistService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            playlistService.AddTrackToPlaylist(trackAdd);

            return Ok();
        }

        /// <summary>
        /// Get List of Playlists
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("Playlist")]
        public IHttpActionResult GetPlaylist()
        {
            PlaylistService playlistService = CreatePlaylistService();

            var playlists = playlistService.GetAllPlaylists();

            return Ok(playlists);
        }

        /// <summary>
        /// Get Contents of a Playlist
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PlaylistContent")]
        public IHttpActionResult GetPlaylistbyContent(int playlistId)
        {
            PlaylistService playlistService = CreatePlaylistService();

            var playlist = playlistService.GetPlaylistContent(playlistId);

            return Ok(playlist);
        }

        /// <summary>
        /// Remove a Playlist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Playlist/{id}")]
        public IHttpActionResult DeletePlaylistById(int id)
        {
            PlaylistService playlistService = CreatePlaylistService();

            playlistService.DeletePlaylist(id);

            return Ok();
        }


        private PlaylistService CreatePlaylistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playlistService = new PlaylistService(userId);
            return playlistService;
        }
    }
}
