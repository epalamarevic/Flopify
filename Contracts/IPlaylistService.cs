using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IPlaylistService
    {
        void CreatePlaylist(CreatePlaylist playlist);
        //IEnumerable<ListPlaylistModel> GetAllPlaylists();
        //void DeletePlaylist(int playlistId);
    }
}
