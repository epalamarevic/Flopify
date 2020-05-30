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
    [RoutePrefix("Flopify/Dislikes")]
    public class DislikeController : ApiController
    {
        //Post api/dislike/track
        /// <summary>
        /// Create a Dislike for Track
        /// </summary>
        /// <param name="dislike">Mandatory: BandID, AlbumID, TrackID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Track/{id}")]
        
        public IHttpActionResult PostTrackDislike(int id)
        {
            DislikeService dislikeService = CreateDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dislikeService.CreateTrackDislike(id);

            return Ok();
        }
        //Post api/dislike/album
        /// <summary>
        /// Create a Dislike for Album
        /// </summary>
        /// <param name="dislike">Mandadtory: BandID, AlbumID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Album/{id}")]
        public IHttpActionResult PostAlbumDislike(int id)
        {
            DislikeService dislikeService = CreateDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dislikeService.CreateAlbumDislike(id);

            return Ok();
        }
        //post api/dislike/band
        /// <summary>
        /// Create a Dislike for Band
        /// </summary>
        /// <param name="dislike">Mandatory: BandID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Band/{id}")]
        public IHttpActionResult PostBandDislike(int id)
        {
            DislikeService dislikeService = CreateDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dislikeService.CreateBandDislike(id);

            return Ok();
        }
        //Get api/dislikes
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
        //Delete api/dislike{id}
        /// <summary>
        /// Delete a Dislike
        /// </summary>
        /// <param name="dislike">Mandatory: DislikeID</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteDislike(int id)
        {
            DislikeService dislikeService = CreateDislikeService();

            dislikeService.DeleteDislike(id);

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
