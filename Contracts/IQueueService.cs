using Models;
using Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IQueueService
    {
        void CreateQueue();
        void AddTrackToQueue(int trackId);
        void AddAlbumToQueue(int albumId);
        void AddBandToQueue(int bandId);
        void DeleteTrackFromQueue(int trackId);
        IEnumerable<TrackListModel> GetAllFromQueue();
        void CreatePlaylistFromQueue(PlaylistCreateModel model);
        void AddToPlayListFromQueue(int playlistId);
        void ClearQueue();
    }
}
