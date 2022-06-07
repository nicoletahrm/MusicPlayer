using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class PlaylistArtist
    {
        public int PlaylistArtistId { get; set; }
        public int PlaylistId { get; set; }
        public int ArtistId { get; set; }
        public string PlaylistName { get; set; }
        public string ArtistName { get; set; }
    }
}
