using Microsoft.AspNet.Identity;
using Models.Album;
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
    public class AlbumController : ApiController
    {
        //Post api/album
        /// <summary>
        /// Create an Album for Band
        /// </summary>
        /// <param name="model">Mandatory: BandID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Album")]
        public IHttpActionResult PostAlbum(AlbumCreateModel model)
        {
            AlbumService albumService = CreateAlbumService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            albumService.CreateAlbum(model);

            return Ok();
        }

        //Get api/album
        /// <summary>
        /// Get all Albums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Album")]
        public IHttpActionResult GetAlbums()
        {
            AlbumService albumService = CreateAlbumService();

            var albums = albumService.GetAllAlbums();

            return Ok(albums);
        }

        //Get api/album
        /// <summary>
        /// Get all Albums in order of Dislikes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AlbumByDislikes")]
        public IHttpActionResult GetAlbumsByDislikes()
        {
            AlbumService albumService = CreateAlbumService();

            var albums = albumService.GetAllAlbumsByDislikes();

            return Ok(albums);
        }

        //Get api/album{id}
        /// <summary>
        /// Get Album by AlbumID
        /// </summary>
        /// <param name="id">Mandatory: AlbumID </param>
        /// <returns></returns>
        [HttpGet]
       [Route("Album/{id}")]
        public IHttpActionResult GetAlbumById(int id)
        {
            AlbumService albumService = CreateAlbumService();

            var album = albumService.GetAlbumById(id);

            return Ok(album);
        }

        //Put api/album
        /// <summary>
        /// Update a Album
        /// </summary>
        /// <param name="model">Mandatory: AlbumID</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Album")]
        public IHttpActionResult PutAlbum(AlbumUpdateModel model)
        {
            AlbumService albumService = CreateAlbumService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            albumService.UpdateAlbum(model);

            return Ok();
        }

        //Delete api/album{id}
        /// <summary>
        /// Delete a Album
        /// </summary>
        /// <param name="id">Mandatory: AlbumID </param>
        /// <returns></returns>
       [HttpDelete]
       [Route("Album/{id}")]
        public IHttpActionResult DeleteAlbumById(int id)
        {
            AlbumService albumService = CreateAlbumService();

            albumService.DeleteAlbum(id);

            return Ok();
        }

        private AlbumService CreateAlbumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumService(userId);
            return albumService;
        }
    }
}
