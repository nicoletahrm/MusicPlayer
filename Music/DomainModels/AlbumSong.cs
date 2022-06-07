using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class AlbumSong
    {
        public int AlbumSongId { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
        public string AlbumName { get; set; }
        public string SongName { get; set; }
    }
}
