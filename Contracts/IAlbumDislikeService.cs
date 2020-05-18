using Models.AlbumDislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAlbumDislikeService
    {
        void CreateAlbumDislike(int albumId);
        IEnumerable<AlbumDislikeList> GetAllAlbumDislikes();
        void DeleteAlbumDislike(int albumDislikeId);
    }
}
