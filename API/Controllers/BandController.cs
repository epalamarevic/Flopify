using Microsoft.AspNet.Identity;
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
        /// Create a Band.
        /// </summary>
        /// <param name="model"></param>
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

        //Get api/Band
        /// <summary>
        /// Get Band by BandID.
        /// </summary>
        /// <param name="id">Mandatory: Need BandId of the Band you wish to retreive.</param>
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
        /// <param name="band">Need BandId to update band.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Band")]
        public IHttpActionResult PutBand(BandEditModel band)
        {
            BandService bandService = CreateBandService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bandService.UpdateBand(band);

            return Ok();
        }
        //Delete api/band{id}
        /// <summary>
        /// Delete a Band
        /// </summary>
        /// <param name="id">Need "BandId" of the Band you wish to remove.</param>
        /// <returns></returns>
        [HttpDelete]
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
