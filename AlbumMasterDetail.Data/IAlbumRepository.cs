using AlbumMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMasterDetail.Data
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAllAlbums();
        Album GetAlbum(int id);
        bool InsertAlbum(Album album);
        bool UpdateAlbum(Album album);
        bool DeleteAlbum(Album album);
    }
}
