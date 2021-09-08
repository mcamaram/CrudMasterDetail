using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlbumMasterDetail.Models;
using AlbumMasterDetail.Data;
using System.Transactions;

namespace AlbumMasterDetail.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumrepository;
        private readonly ISongRepository _songrepository;

        public AlbumService()
        {
            _albumrepository = new AlbumRepository();
            _songrepository = new SongRepository();
        }
        public bool DeleteAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public bool SaveAlbum(Album album)
        {
            bool ok = false;
            using (TransactionScope ts = new TransactionScope())
            {  
                if (album.Id == Guid.Empty)
                {
                    album.Id = Guid.NewGuid();
                    ok = _albumrepository.InsertAlbum(album);
                    if (ok)
                    {
                        foreach (var item in album.Songs)
                        {
                            item.AlbumId = album.Id;
                            _songrepository.InsertSong(item);
                        }
                    }

                    ts.Complete();
                }
                return ok;
            }  
        }
    }
}
