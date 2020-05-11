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
    public class AlbumController : ApiController
    {
        public IHttpActionResult PostAlbum(AlbumCreate model)
        {
            AlbumService albumService = CreateAlbumService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            albumService.CreateAlbum(model);

            return Ok();
        }

        public IHttpActionResult GetAlbums()
        {
            AlbumService albumService = CreateAlbumService();

            var albums = albumService.GetAllAlbums();

            return Ok(albums);
        }

        public IHttpActionResult GetAlbumById(int id)
        {
            AlbumService albumService = CreateAlbumService();

            var album = albumService.GetAlbumById(id);

            return Ok(album);
        }

        public IHttpActionResult PutAlbum(AlbumUpdate model)
        {
            AlbumService albumService = CreateAlbumService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            albumService.UpdateAlbum(model);

            return Ok();
        }

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
