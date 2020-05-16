using Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITrackServices
    {
        void CreateTrack(CreateTrack model);
        IEnumerable<TrackList> GetAllTracks();
        TrackDetail GetTrackById(int trackId);
        void UpdateTrack(UpdateTrack model);
        void DeleteTrack(int trackId);
    }
}
