using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class PlaylistAlbum
    {
        public int PlaylistAlbumId { get; set; }
        public int PlaylistId { get; set; }
        public int AlbumId { get; set; }
        public string PlaylistName { get; set; }
        public string AlbumName { get; set; }
    }
}
