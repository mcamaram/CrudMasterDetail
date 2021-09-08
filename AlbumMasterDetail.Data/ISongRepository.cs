using AlbumMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMasterDetail.Data
{
    public interface ISongRepository
    {
        IEnumerable<Song> GetAllSongs();
        Song GetSong(int id);
        bool InsertSong(Song song);
        bool UpdateSong(Song song);
        bool DeleteSong(Song song);
    }
}
