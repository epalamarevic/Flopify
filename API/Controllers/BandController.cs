﻿using Microsoft.AspNet.Identity;
using Models.Band;
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
    public class BandController : ApiController
    {
        //Post api/band
        /// <summary>
        /// Create a Band
        /// </summary>
        /// <param name="band"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Band")]
        public IHttpActionResult PostBand(BandCreateModel band)
        {
            BandService bandService = CreateBandService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bandService.CreateBand(band);

            return Ok();
        }

        //Get api/band
        /// <summary>
        /// Get all Bands
        /// </summary>
        /// <returns></returns>
       [HttpGet]
       [Route("Band")]
        public IHttpActionResult GetBands()
        {
            BandService bandService = CreateBandService();

            var tracks = bandService.GetAllBands();

            return Ok(tracks);
        }

        //Get api/band
        /// <summary>
        /// Get all Bands in order of Dislikes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("BandByDislikes")]
        public IHttpActionResult GetBandsByDislikes()
        {
            BandService bandService = CreateBandService();

            var bands = bandService.GetAllBandsByDislikes();

            return Ok(bands);
        }

        //Get api/Band
        /// <summary>
        /// Get Band by BandID
        /// </summary>
        /// <param name="id">Mandatory: BandID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Band/{id}")]
        public IHttpActionResult GetBand(int id)
        {
            BandService bandService = CreateBandService();

            var track = bandService.GetBandById(id);

            return Ok(track);
        }

        //Put api/band{id}
        /// <summary>
        /// Update a Band
        /// </summary>
        /// <param name="band">Mandatory: BandID</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Band")]
        public IHttpActionResult PutBand(BandUpdateModel band)
        {
            BandService bandService = CreateBandService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bandService.UpdateBand(band);

            return Ok();
        }

        //Patch api/band{id}
        /// <summary>
        /// Delete a Band
        /// </summary>
        /// <param name="id">Mandatory: BandID</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Band/{id}")]
        public IHttpActionResult DeleteBandById(int id)
        {
            BandService bandService = CreateBandService();

            bandService.DeleteBand(id);

            return Ok();
        }

        private BandService CreateBandService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bandService = new BandService(userId);
            return bandService;
        }
    }
}
