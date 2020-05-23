using Contracts;
using Data;
using Models.Band;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BandService : IBandServices
    {
        // Constructor to catch the User Id that is passed in through the Controller
        private readonly Guid _userId;
        public BandService(Guid userId)
        {
            _userId = userId;
        }

        // Method to Create a Band
        public void CreateBand(BandCreateModel band)
        {
            var entity = new Band()
            {
                Name = band.Name,
                Genre = band.Genre,
                Members = band.Members,
                UserId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bands.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Method to List all Bands
        public IEnumerable<BandListModel> GetAllBands()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.Bands.Where(e => e.IsActive == true).Select(e => new BandListModel { BandId = e.BandId, Name = e.Name, Genre = e.Genre });

                return request.ToArray();
            }
        }

        // Method to Get a specific Band by the Band Id
        public BandDetailModel GetBandById(int bandId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bands.Single(e => e.BandId == bandId);

                return new BandDetailModel
                {
                    BandId = entity.BandId,
                    Name = entity.Name,
                    Genre = entity.Genre,
                    Members = entity.Members,
                    NumberOfAlbums = entity.NumberOfAlbums,
                    Dislikes = entity.Dislikes
                };
            }
        }

        // Method to Update a Band by the Band Id
        public void UpdateBand(BandEditModel band)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bands.Single(e => e.BandId == band.BandId/* && e.UserId == _userId -Uncomment this to ensure that Bands are only able to be edited by the user that created them- */);
                // Uncomment the portion above to ensure that Bands are only able to be edited by the user that created them

                entity.Name = band.Name;
                entity.Genre = band.Genre;
                entity.Members = band.Members;

                ctx.SaveChanges();
            }
        }

        // Method to Delete a Band by the Band Id
        public void DeleteBand(int bandId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bands.Single(e => e.BandId == bandId/* && e.UserId == _userId*/);
                // Uncomment the portion above to ensure that Bands are only able to be deleted by the user that created them

                entity.IsActive = false;

                ctx.SaveChanges();
            }
        }
    }
}
