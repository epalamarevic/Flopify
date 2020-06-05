using Models.Dislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDislikeService
    {
        void CreateTrackDislike(int trackId);
        void CreateAlbumDislike(int albumId);
        void CreateBandDislike(int bandId);
        IEnumerable<DislikeListModel> ListDislikes();
        void DeleteDislike(int dislikeId);
    }
}
