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
        void CreateTrackDislike(DislikeCreateTrackModel dislike);
        void CreateAlbumDislike(DislikeCreateAlbumModel dislike);
        void CreateBandDislike(DislikeCreateBandModel dislike);
        IEnumerable<DislikeListModel> ListDislikes();
        void DeleteDislike(int dislikeId);
    }
}
