using AlbumMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMasterDetail.Service
{
    public interface ISongService
    {
        IEnumerable<Song> GetAllSongs();
        bool SaveSong(Song song);
        bool DeleteSong(Song song);
    }
}
