using Models;
using Models.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IPlaylistService
    {
        void CreatePlaylist(CreatePlaylist model);
        void AddTrackToPlaylist(TrackAddModel ids);
        IEnumerable<ListPlaylistModel> GetAllPlaylists();
        void DeletePlaylist(int playlistId);
    }
}
