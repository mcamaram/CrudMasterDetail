using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMasterDetail.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime RealeseDate { get; set; }
        public List<Song> Songs { get; set; }
    }
}
