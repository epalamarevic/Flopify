using Contracts;
using Microsoft.AspNet.Identity;
using Models.Track;
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
    public class TrackController : ApiController
    {

        //Post api/track
        /// <summary>
        /// Create a Track
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Track")]
        public IHttpActionResult PostTrack(TrackCreateModel model)
        {
            TrackService trackService = CreateTrackService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            trackService.CreateTrack(model);

            return Ok();
        }

        //Get api/track
        /// <summary>
        /// Get all Tracks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Track")]
        public IHttpActionResult GetTracks()
        {
            TrackService trackService = CreateTrackService();

            var tracks = trackService.GetAllTracks();

            return Ok(tracks);
        }

        //Get api/track
        /// <summary>
        /// Get all Tracks in order of Dislikes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TrackByDislikes")]
        public IHttpActionResult GetTracksByDislikes()
        {
            TrackService trackService = CreateTrackService();

            var tracks = trackService.GetAllTracksByDislikes();

            return Ok(tracks);
        }

        //Get api/track{id}
        /// <summary>
        /// Get a Track by TrackID
        /// </summary>
        /// <param name="id">Mandatory: TrackID </param>
        /// <returns></returns>
        [HttpGet]
       [Route("Track/{id}")]
        public IHttpActionResult GetTrack(int id)
        {
            TrackService trackService = CreateTrackService();

            var track = trackService.GetTrackById(id);

            return Ok(track);
        }

        //Put api/track{id}
        /// <summary>
        /// Update a Track
        /// </summary>
        /// <param name="model">Mandatory: TrackID</param>
        /// <returns></returns>
       [HttpPut]
       [Route("Track")]
        public IHttpActionResult PutTrack(TrackUpdateModel model)
        {
            TrackService trackService = CreateTrackService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            trackService.UpdateTrack(model);

            return Ok();
        }

        //Delete api/track{id}
        /// <summary>
        /// Delete a Track
        /// </summary>
        /// <param name="id">Mandatory: TrackID</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Track/{id}")]
        public IHttpActionResult DeleteTrackById(int id)
        {
            TrackService trackService = CreateTrackService();

            trackService.DeleteTrack(id);

            return Ok();
        }

        private TrackService CreateTrackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var trackService = new TrackService(userId);
            return trackService;
        }
    }
}
