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
        public IHttpActionResult PostTrack(BandCreateModel band)
        {
            BandServices bandService = new BandServices();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bandService.CreateBand(band);

            return Ok();
        }

        public IHttpActionResult GetTracks()
        {
            BandServices bandService = new BandServices();

            var tracks = bandService.GetAllBands();

            return Ok(tracks);
        }

        public IHttpActionResult GetTrack(int id)
        {
            BandServices bandService = new BandServices();

            var track = bandService.GetBandById(id);

            return Ok(track);
        }

        public IHttpActionResult PutTrack(BandEditModel band)
        {
            BandServices bandService = new BandServices();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bandService.UpdateBand(band);

            return Ok();
        }

        public IHttpActionResult DeleteTrackById(int id)
        {
            BandServices bandService = new BandServices();

            bandService.DeleteBand(id);

            return Ok();
        }
    }
}
