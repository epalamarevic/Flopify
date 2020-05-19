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
    public class TrackController : ApiController
    {

        //Post api/track
        /// <summary>
        /// Create a Track
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IHttpActionResult PostTrack(CreateTrack model)
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
        public IHttpActionResult GetTracks()
        {
            TrackService trackService = CreateTrackService();

            var tracks = trackService.GetAllTracks();

            return Ok(tracks);
        }


        //Get api/track{id}
        /// <summary>
        /// Get a Track by TrackID
        /// </summary>
        /// <param name="id">Need "trackID" of the Track you wish to retreive </param>
        /// <returns></returns>
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
        /// <param name="model">Need trackId to update a track</param>
        /// <returns></returns>
        public IHttpActionResult PutTrack(UpdateTrack model)
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
        /// <param name="id">Need "trackId" of the Track you wish to remove</param>
        /// <returns></returns>
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
