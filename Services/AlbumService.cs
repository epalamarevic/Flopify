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
        // Constructor to catch the User Id that is passed in through the Controller
        private readonly Guid _userId;
        public AlbumService(Guid userId)
        {
            _userId = userId;
        }

        // Method to Create an Album
        public void CreateAlbum(AlbumCreateModel model)
        {
            var entity =
                new Album()
                {
                    Title = model.Title,
                    DateReleased = model.DateReleased,
                    BandId = model.BandId,
                    UserId = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                ctx.SaveChanges();
            }
        }

        // Method to List all Albums
        public IEnumerable<AlbumListModel> GetAllAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request = ctx.Albums.Where(e => e.IsActive == true).Select(e => new AlbumListModel { AlbumId = e.AlbumId, Title = e.Title, BandId = e.BandId });
                return request.ToArray();
            }
        }

        // Method to List all Albums, ordered by most Disliked
        public IEnumerable<AlbumListByDislikesModel> GetAllAlbumsByDislikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var request =
                    ctx
                        .Albums
                        .Where(e => e.IsActive == true)
                        .Select(e => new AlbumListByDislikesModel
                        {
                            AlbumId = e.AlbumId,
                            Title = e.Title,
                            BandId = e.BandId,
                            Dislikes = ctx.Dislikes.Where(x => x.IsActive == true && x.AlbumId == e.AlbumId).Count()
                        }).OrderByDescending(d => d.Dislikes);

                return request.ToArray();
            }
        }

        // Method to Get a specific Album by the Album Id
        public AlbumDetailModel GetAlbumById(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
              
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == albumId);
                return
                    new AlbumDetailModel
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

        // Method to Update an Album by the Album Id
        public void UpdateAlbum(AlbumUpdateModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumId == model.AlbumId /*&& e.UserId == _userId*/);
                // Uncomment the portion above to ensure that Albums are only able to be edited by the user that created them

                entity.Title = model.Title;
                entity.DateReleased = model.DateReleased;

                ctx.SaveChanges();
            }
        }

        // Method to Delete an Album by the Album Id
        public void DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var itemToDelete = ctx.Albums.Single(e => e.AlbumId == albumId/* && e.UserId == _userId*/);
                // Uncomment the portion above to ensure that Albums are only able to be deleted by the user that created them

                itemToDelete.IsActive = false;
                ctx.SaveChanges();
            }
        }
    }
}
