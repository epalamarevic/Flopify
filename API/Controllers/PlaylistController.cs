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
    [RoutePrefix("Flopify/Playlist")]
    public class PlaylistController : ApiController
    {
        //Post api/playlist
        /// <summary>
        /// Create a Playlist
        /// </summary>
        /// <param name="playlist">Mandatory: Title</param>
        /// <returns></returns>
        [HttpPost]
        [Route]
        public IHttpActionResult PostPlaylist(PlaylistCreateModel playlist)
        {
            PlaylistService playlistService = CreatePlaylistService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            playlistService.CreatePlaylist(playlist);

            return Ok();
        }

        //Patch api/playlist/posttracktoplaylist
        /// <summary>
        /// Post a Track to Playlist
        /// </summary>
        /// <param name="track">Mandatory: PlaylistId, TrackId</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("PostTrackToPlaylist")]
        public IHttpActionResult PostTrackToPlaylist(PlaylistTrackAddModel track)
        {
            PlaylistService playlistService = CreatePlaylistService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            playlistService.AddTrackToPlaylist(track);

            return Ok();
        }

        //Get api/playlist
        /// <summary>
        /// Get a List of Playlists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route]
        public IHttpActionResult GetPlaylist()
        {
            PlaylistService playlistService = CreatePlaylistService();

            var playlists = playlistService.GetAllPlaylists();

            return Ok(playlists);
        }

        //Get api/playlist/{id}
        /// <summary>
        /// Get Contents of a Playlist
        /// </summary>
        /// <param name="playlistId">Mandatory: PlaylistId</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetPlaylistbyContent(int playlistId)
        {
            PlaylistService playlistService = CreatePlaylistService();

            var playlist = playlistService.GetPlaylistContent(playlistId);

            return Ok(playlist);
        }

        //Patch api/playlist/deleteplaylisttrack
        /// <summary>
        /// Remove a Track from a Playlist
        /// </summary>
        /// <param name="model">Mandatory: PlaylistId, TrackId</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("DeletePlaylistTrack")]
        public IHttpActionResult DeleteTrackById(PlaylistTrackDeleteModel model)
        {
            PlaylistService playlistService = CreatePlaylistService();

            playlistService.DeleteTrack(model);

            return Ok();
        }

        //Patch api/playlist/{id}
        /// <summary>
        /// Remove a Playlist
        /// </summary>
        /// <param name="id">Mandatory: PlaylistId</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id}")]
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
