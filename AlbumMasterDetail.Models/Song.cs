using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMasterDetail.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public string Name { get; set; }
        public int Minutes { get; set; }
    }
}
