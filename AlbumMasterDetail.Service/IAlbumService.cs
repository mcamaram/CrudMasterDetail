using AlbumMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMasterDetail.Service
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAllAlbums();
        bool SaveAlbum(Album album);
        bool DeleteAlbum(Album album);
    }
}
