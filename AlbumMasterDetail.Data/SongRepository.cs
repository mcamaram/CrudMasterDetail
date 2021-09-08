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
    public class SongRepository : GenericRepository, ISongRepository
    {
        public bool DeleteSong(Song song)
        {
            using(var db = dbConnection())
            {
                var sql = "spDeleteSong";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", song.Id);

                var result = db.Execute(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public IEnumerable<Song> GetAllSongs()
        {
            using(var db = dbConnection())
            {
                var sql = "spGetAllSongs";
                var parameters = new DynamicParameters();

                var result = db.Query<Song>(sql, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public Song GetSong(int id)
        {
            using(var db = dbConnection())
            {
                var sql = "spGetSong";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = db.QuerySingle<Song>(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public bool InsertSong(Song song)
        {
            using(var db = dbConnection())
            {
                var sql = "spInsertSong";
                var parameters = new DynamicParameters();
                parameters.Add("@AlbumId", song.AlbumId);
                parameters.Add("@Name", song.Name);
                parameters.Add("@Minutes", song.Minutes);

                var result = db.Execute(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool UpdateSong(Song song)
        {
            using (var db = dbConnection())
            {
                var sql = "spUpdateSong";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", song.Id);
                parameters.Add("@AlbumId", song.AlbumId);
                parameters.Add("@Name", song.Name);
                parameters.Add("@Minutes", song.Minutes);

                var result = db.Execute(sql, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
