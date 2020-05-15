using Contracts;
using Data;
using Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AlbumService : IAlbumService
    {
        // Checking UserId to set later for each service
        private readonly Guid _userId;
        public AlbumService(Guid userId)
        {
            _userId = userId;
        }

        // Service to Create an Album
        public void CreateAlbum(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    Title = model.Title,
                    DateReleased = model.DateReleased,
                    BandId = model.BandId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Service to Delete an Album by AlbumId
        public void DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.Albums.Single(e => e.AlbumId == albumId);
                ctx.Albums.Remove(itemToDelete);
                ctx.SaveChanges();
            }
        }

        // Service to Get a specific Album by the AlbumId
        public AlbumDetail GetAlbumById(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == albumId);
                return
                    new AlbumDetail
                    {
                        AlbumId = entity.AlbumId,
                        Title = entity.Title,
                        PlayTime = TimeSpan.FromTicks(entity.PlayTimeTicks),
                        NumberOfTracks = entity.NumberOfTracks,
                        DateReleased = entity.DateReleased,
                        BandId = entity.BandId
                    };
            }
        }

        // Service to Return all Albums in an IEnumerable List
        public IEnumerable<AlbumList> GetAllAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.Albums.Select(e => new AlbumList { AlbumId = e.AlbumId, Title = e.Title, PlayTime = TimeSpan.FromTicks(e.PlayTimeTicks), NumberOfTracks = e.NumberOfTracks, BandId = e.BandId });
                return request.ToArray();
            }
        }

        // Service to Update an Album by AlbumId in the body
        public void UpdateAlbum(AlbumUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == model.AlbumId);

                entity.Title = model.Title;
                entity.DateReleased = model.DateReleased;

                ctx.SaveChanges();
            }
        }
    }
}
