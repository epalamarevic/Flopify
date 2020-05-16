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
        void CreateAlbum(AlbumCreate model);
        IEnumerable<AlbumList> GetAllAlbums();
        AlbumDetail GetAlbumById(int albumId);
        void UpdateAlbum(AlbumUpdate model);
        void DeleteAlbum(int albumId);
    }
}
