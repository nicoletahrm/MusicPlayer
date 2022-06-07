using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoamainModels
{
    public class PlaylistSong
    {
        public int PlaylistSongId  { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public string PlaylistName { get; set; }
        public string SongName { get; set; }
    }
}
