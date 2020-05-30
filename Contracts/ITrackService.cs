using Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITrackService
    {
        void CreateTrack(TrackCreateModel model);
        IEnumerable<TrackListModel> GetAllTracks();
        IEnumerable<TrackListByDislikesModel> GetAllTracksByDislikes();
        TrackDetailModel GetTrackById(int trackId);
        void UpdateTrack(TrackUpdateModel model);
        void DeleteTrack(int trackId);
    }
}
