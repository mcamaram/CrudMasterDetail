using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMasterDetail.Data
{
    public abstract class GenericRepository
    {
        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        }
    }
}
