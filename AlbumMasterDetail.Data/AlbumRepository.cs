using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlbumMasterDetail.Models;
using Dapper;
using System.Data;

namespace AlbumMasterDetail.Data
{
    public class AlbumRepository : GenericRepository, IAlbumRepository
    {
        public bool DeleteAlbum(Album album)
        {
            using (var db = dbConnection())
            {
                var sql = "spDeleteAlbum";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", album.Id);
                var result = db.Execute(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            using (var db = dbConnection())
            {
                var sql = "spGetAllAlbums";
            
                var albums = db.Query<Album>(sql, commandType: CommandType.StoredProcedure);
                return albums;
            }
        }

        public Album GetAlbum(int id)
        {
            using (var db = dbConnection())
            {
                var sql = "spGetAlbum";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var album = db.QuerySingle<Album>(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return album;
            }
        }

        public bool InsertAlbum(Album album)
        {
            using (var db = dbConnection())
            {
                var sql = "spInsertAlbum";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", album.Id);
                parameters.Add("@Name", album.Name);
                parameters.Add("@Author", album.Author);
                parameters.Add("@ReleaseDate", album.RealeseDate);
                var result = db.Execute(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool UpdateAlbum(Album album)
        {
            using (var db = dbConnection())
            {
                var sql = "spUpdateAlbum";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", album.Id);
                parameters.Add("@Name", album.Name);
                parameters.Add("@Author", album.Author);
                parameters.Add("@ReleaseDate", album.RealeseDate);
                var result = db.Execute(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
