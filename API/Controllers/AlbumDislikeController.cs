using Microsoft.AspNet.Identity;
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
    public class AlbumDislikeController : ApiController
    {
        public IHttpActionResult PostAlbumDislike(int albumId)
        {
            AlbumDislikeService AlbumDislikeService = CreateAlbumDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AlbumDislikeService.CreateAlbumDislike(albumId);

            return Ok();
        }

        public IHttpActionResult GetAlbumDislikes()
        {
            AlbumDislikeService AlbumDislikeService = CreateAlbumDislikeService();

            var AlbumDislikes = AlbumDislikeService.GetAllAlbumDislikes();

            return Ok(AlbumDislikes);
        }
        public IHttpActionResult DeleteAlbumDislikeById(int albumId)
        {
            AlbumDislikeService AlbumDislikeService = CreateAlbumDislikeService();

            AlbumDislikeService.DeleteAlbumDislike(albumId);

            return Ok();
        }

        private AlbumDislikeService CreateAlbumDislikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var AlbumDislikeService = new AlbumDislikeService(userId);
            return AlbumDislikeService;
        }
    }
}
