using Models.TrackDislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface ITrackDislikeService
    {
        void CreateDislike(TrackDislikeCreate model);
        IEnumerable<TrackDislikeList> GetAllDislikes();
        void DeleteDislike(int trackDislikeId);
    }
}
