using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlbumMasterDetail.Models;
using AlbumMasterDetail.Data;

namespace AlbumMasterDetail.Service
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songrepository;

        public SongService()
        {
            _songrepository = new SongRepository();
        }
        public bool DeleteSong(Song song)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetAllSongs()
        {
            throw new NotImplementedException();
        }

        public bool SaveSong(Song song)
        {
            bool ok = false;
            if(song.Id == Guid.Empty)
            {
                ok = _songrepository.InsertSong(song);
            }
            else
            {
                ok = _songrepository.UpdateSong(song);
            }
            return ok;
        }
    }
}
