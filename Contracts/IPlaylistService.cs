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
        void CreatePlaylist(PlaylistCreateModel model);
        void AddTrackToPlaylist(PlaylistTrackAddModel ids);
        void DeleteTrack(PlaylistTrackDeleteModel model);
        IEnumerable<PlaylistListModel> GetAllPlaylists();
        void DeletePlaylist(int playlistId);
    }
}
