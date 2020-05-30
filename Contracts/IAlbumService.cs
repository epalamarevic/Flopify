using Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAlbumService
    {
        void CreateAlbum(AlbumCreateModel model);
        IEnumerable<AlbumListModel> GetAllAlbums();
        IEnumerable<AlbumListByDislikesModel> GetAllAlbumsByDislikes();
        AlbumDetailModel GetAlbumById(int albumId);
        void UpdateAlbum(AlbumUpdateModel model);
        void DeleteAlbum(int albumId);
    }
}
