using Microsoft.AspNet.Identity;
using Models;
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
    [RoutePrefix("Flopify/Queue")]
    public class QueueController : ApiController
    {
        [HttpPost]
        [Route]
        public IHttpActionResult CreateQueue()
        {
            QueueService queueService = CreateQueueService();

            queueService.CreateQueue();

            return Ok();
        }

        [HttpGet]
        [Route]
        public IHttpActionResult GetQueue()
        {
            QueueService queueService = CreateQueueService();

            var queue = queueService.GetAllFromQueue();

            return Ok(queue);
        }

        [HttpPatch]
        [Route("Track/{id}")]
        public IHttpActionResult AddTrack(int id)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.AddTrackToQueue(id);

            return Ok();
        }

        [HttpPatch]
        [Route("Album/{id}")]
        public IHttpActionResult AddAlbum(int id)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.AddAlbumToQueue(id);

            return Ok();
        }

        [HttpPatch]
        [Route("Band/{id}")]
        public IHttpActionResult AddBand(int id)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.AddBandToQueue(id);

            return Ok();
        }

        [HttpPost]
        [Route("CreatePlaylist")]
        public IHttpActionResult CreatePlaylistFromQueue(CreatePlaylist model)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.CreatePlaylistFromQueue(model);

            return Ok();
        }

        [HttpPatch]
        [Route("AddToPlaylist/{id}")]
        public IHttpActionResult AddQueueToPlaylist(int id)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.AddToPlayListFromQueue(id);

            return Ok();
        }

        [HttpPatch]
        [Route("Clear")]
        public IHttpActionResult ClearQueue()
        {
            QueueService queueService = CreateQueueService();

            queueService.ClearQueue();

            return Ok();
        }

        private QueueService CreateQueueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var queueService = new QueueService(userId);
            return queueService;
        }
    }
}
