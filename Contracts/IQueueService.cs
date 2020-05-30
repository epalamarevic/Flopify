using Models.Queue;
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
        void AddTrackToQueue(QueueUpdateAddTrackModel model);
        void AddAlbumToQueue(QueueUpdateAddAlbumModel model);
        void AddBandToQueue(QueueUpdateAddBandModel model);
        IEnumerable<TrackListModel> GetAllFromQueue();
        void CreatePlaylistFromQueue();
        void AddToPlayListFromQueue(int playlistId);
        void ClearQueue();
    }
}
