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
        void CreateTrackDislike(CreateTrackDislikeModel dislike);
        void CreateAlbumDislike(CreateAlbumDislikeModel dislike);
        void CreateBandDislike(CreateBandDislikeModel dislike);
        IEnumerable<ListDislikeModel> ListDislikes();
        void DeleteDislike(int dislikeId);
    }
}
