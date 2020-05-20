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
    [RoutePrefix("api/Dislikes")]
    public class DislikeController : ApiController
    {
        /// <summary>
        /// Create a Dislike for Track
        /// </summary>
        /// <param name="dislike">Mandatory: Need BandID, AlbumID, TrackID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Track")]
        
        public IHttpActionResult PostTrackDislike(CreateTrackDislikeModel dislike)
        {
            DislikeService dislikeService = CreateDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dislikeService.CreateTrackDislike(dislike);

            return Ok();
        }

        /// <summary>
        /// Create a Dislike for Album
        /// </summary>
        /// <param name="dislike">Mandadtory: Need BandID and AlbumID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Album")]
        public IHttpActionResult PostAlbumDislike(CreateAlbumDislikeModel dislike)
        {
            DislikeService dislikeService = CreateDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dislikeService.CreateAlbumDislike(dislike);

            return Ok();
        }

        /// <summary>
        /// Create a Dislike for Band
        /// </summary>
        /// <param name="dislike">Mandatory:Need BandID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Band")]
        public IHttpActionResult PostBandDislike(CreateBandDislikeModel dislike)
        {
            DislikeService dislikeService = CreateDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dislikeService.CreateBandDislike(dislike);

            return Ok();
        }
        /// <summary>
        /// Get all Dislikes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route]
        public IHttpActionResult GetDislikes()
        {
            DislikeService dislikeService = CreateDislikeService();

            var dislikes = dislikeService.ListDislikes();

            return Ok(dislikes);
        }

        /// <summary>
        /// Delete a Dislike
        /// </summary>
        /// <param name="dislike">Mandatory:Need DislikeID</param>
        /// <returns></returns>
        [HttpDelete]
        [Route]
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
