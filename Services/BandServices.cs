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
    public class BandServices : IBandServices
    {
        public void CreateBand(BandCreateModel band)
        {
            var entity = new Band()
            {
                Name = band.Name,
                Genre = band.Genre,
                Members = band.Members
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bands.Add(entity);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<BandListModel> GetAllBands()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.Bands.Select(e => new BandListModel { BandId = e.BandId, Name = e.Name, Genre = e.Genre });

                return request.ToArray();
            }
        }

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

        public void UpdateBand(BandEditModel band)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bands.Single(e => e.BandId == band.BandId);

                entity.Name = band.Name;
                entity.Genre = band.Genre;
                entity.Members = band.Members;

                ctx.SaveChanges();
            }
        }

        public void DeleteBand(int bandId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bands.Single(e => e.BandId == bandId);

                ctx.Bands.Remove(entity);

                ctx.SaveChanges();
            }
        }
    }
}
