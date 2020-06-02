using Microsoft.AspNet.Identity;
using Models;
using Models.Queue;
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
        [Route("Track")]
        public IHttpActionResult AddTrack(QueueUpdateAddTrackModel model)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.AddTrackToQueue(model);

            return Ok();
        }

        [HttpPatch]
        [Route("Album")]
        public IHttpActionResult AddAlbum(QueueUpdateAddAlbumModel model)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.AddAlbumToQueue(model);

            return Ok();
        }

        [HttpPatch]
        [Route("Band")]
        public IHttpActionResult AddBand(QueueUpdateAddBandModel model)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.AddBandToQueue(model);

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
