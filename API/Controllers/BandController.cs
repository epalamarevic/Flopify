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
    public class BandController : ApiController
    {
        //Post api/band
        /// <summary>
        /// Create a Band.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IHttpActionResult PostBand(BandCreateModel band)
        {
            BandService bandService = new BandService();

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
        public IHttpActionResult GetBands()
        {
            BandService bandService = new BandService();

            var tracks = bandService.GetAllBands();

            return Ok(tracks);
        }

        //Get api/Band
        /// <summary>
        /// Get Band by BandID.
        /// </summary>
        /// <param name="id">Mandatory: Need BandId of the Band you wish to retreive.</param>
        /// <returns></returns>
        public IHttpActionResult GetBand(int id)
        {
            BandService bandService = new BandService();

            var track = bandService.GetBandById(id);

            return Ok(track);
        }

        //Put api/band{id}
        /// <summary>
        /// Update a Band
        /// </summary>
        /// <param name="band">Need BandId to update band.</param>
        /// <returns></returns>
        public IHttpActionResult PutBand(BandEditModel band)
        {
            BandService bandService = new BandService();

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

        public IHttpActionResult DeleteBandById(int id)
        {
            BandService bandService = new BandService();

            bandService.DeleteBand(id);

            return Ok();
        }
    }
}
