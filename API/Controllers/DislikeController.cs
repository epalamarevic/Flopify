using Microsoft.AspNet.Identity;
using Models.Dislike;
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
    public class DislikeController : ApiController
    {
        public IHttpActionResult PostDislike(CreateDislikeModel dislike)
        {
            DislikeService dislikeService = CreateDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dislikeService.CreateDislike(dislike);

            return Ok();
        }

        public IHttpActionResult GetDislikes()
        {
            DislikeService dislikeService = CreateDislikeService();

            var dislikes = dislikeService.ListDislikes();

            return Ok(dislikes);
        }

        public IHttpActionResult DeleteDislike(DeleteDislikeModel dislike)
        {
            DislikeService dislikeService = CreateDislikeService();

            dislikeService.DeleteDislike(dislike);

            return Ok();
        }

        private DislikeService CreateDislikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dislikeService = new DislikeService(userId);
            return dislikeService;
        }
    }
}
