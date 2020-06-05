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
        //Post api/queue
        /// <summary>
        /// Create a Queue
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route]
        public IHttpActionResult CreateQueue()
        {
            QueueService queueService = CreateQueueService();

            queueService.CreateQueue();

            return Ok();
        }

        //Get api/queue
        /// <summary>
        /// Get all Tracks in Queue
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route]
        public IHttpActionResult GetQueue()
        {
            QueueService queueService = CreateQueueService();

            var queue = queueService.GetAllFromQueue();

            return Ok(queue);
        }

        //Patch api/queue/track/{id}
        /// <summary>
        /// Add a Track to Queue
        /// </summary>
        /// <param name="id">Mandatory: TrackID</param>
        /// <returns></returns>
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

        //Patch api/queue/album/{id}
        /// <summary>
        /// Add all Tracks from an Album to Queue
        /// </summary>
        /// <param name="id">Mandatory: AlbumID</param>
        /// <returns></returns>
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

        //Patch api/queue/band/{id}
        /// <summary>
        /// Add all Tracks from a Band to Queue
        /// </summary>
        /// <param name="id">Mandatory: BandID</param>
        /// <returns></returns>
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

        //Post api/queue/createplaylist
        /// <summary>
        /// Create a Playlist from Queue
        /// </summary>
        /// <param name="model">Mandatory: Title</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreatePlaylist")]
        public IHttpActionResult CreatePlaylistFromQueue(PlaylistCreateModel model)
        {
            QueueService queueService = CreateQueueService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            queueService.CreatePlaylistFromQueue(model);

            return Ok();
        }

        //Patch api/queue/addtoplaylist/{id}
        /// <summary>
        /// Add all Tracks in Queue to Playlist
        /// </summary>
        /// <param name="id">Mandatory: PlaylistID</param>
        /// <returns></returns>
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

        //Patch api/queue
        /// <summary>
        /// Remove a Track from the Queue
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Route("Remove/{id}")]
        public IHttpActionResult DeleteTrack(int id)
        {
            QueueService queueService = CreateQueueService();

            queueService.DeleteTrackFromQueue(id);

            return Ok();
        }

        //Put api/queue
        /// <summary>
        /// Clear the Queue
        /// </summary>
        /// <returns></returns>
        [HttpPut]
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
