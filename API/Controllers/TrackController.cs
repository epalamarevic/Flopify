using Contracts;
using Microsoft.AspNet.Identity;
using Models.Track;
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
        public IHttpActionResult PostTrack(CreateTrack model)
        {
            TrackService trackService = CreateTrackService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            trackService.CreateTrack(model);

            return Ok();
        }

        public IHttpActionResult GetTracks()
        {
            TrackService trackService = CreateTrackService();

            var tracks = trackService.GetAllTracks();

            return Ok(tracks);
        }

        public IHttpActionResult GetTrack(int id)
        {
            TrackService trackService = CreateTrackService();

            var track = trackService.GetTrackById(id);

            return Ok(track);
        }

        public IHttpActionResult PutTrack(UpdateTrack model)
        {
            TrackService trackService = CreateTrackService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            trackService.UpdateTrack(model);

            return Ok();
        }

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
