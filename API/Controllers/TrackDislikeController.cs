﻿using Microsoft.AspNet.Identity;
using Models.TrackDislike;
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
    public class TrackDislikeController : ApiController
    {
        public IHttpActionResult PostTrackDislike(TrackDislikeCreate model)
        {
            TrackDislikeService trackDislikeService = CreateTrackDislikeService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            trackDislikeService.CreateDislike(model);

            return Ok();
        }

        public IHttpActionResult GetTrackDislikes()
        {
            TrackDislikeService trackDislikeService = CreateTrackDislikeService();

            var TrackDislikes = trackDislikeService.GetAllDislikes();

            return Ok(TrackDislikes);
        }
        public IHttpActionResult DeleteTrackDislikeById(int id)
        {
            TrackDislikeService trackDislikeService = CreateTrackDislikeService();

            trackDislikeService.DeleteDislike(id);

            return Ok();
        }

        private TrackDislikeService CreateTrackDislikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var trackDislikeService = new TrackDislikeService(userId);
            return trackDislikeService;
        }
    }
}