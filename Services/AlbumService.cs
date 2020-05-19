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
        private readonly Guid _userId;
        public AlbumService(Guid userId)
        {
            _userId = userId;
        }

        public void CreateAlbum(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    Title = model.Title,
                    DateReleased = model.DateReleased,
                    BandId = model.BandId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.Albums.Single(e => e.AlbumId == albumId);
                ctx.Albums.Remove(itemToDelete);
                ctx.SaveChanges();
            }
        }

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
                        NumberOfTracks = entity.NumberOfTracks,
                        DateReleased = entity.DateReleased,
                        BandId = entity.BandId,
                        TotalPlayTime = entity.TotalPlaytime,
                        Dislikes = entity.Dislikes
                    };
            }
        }

        public IEnumerable<AlbumList> GetAllAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.Albums.Select(e => new AlbumList { AlbumId = e.AlbumId, Title = e.Title, BandId = e.BandId });
                return request.ToArray();
            }
        }

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
