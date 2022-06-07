using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class ArtistSong
    {
        [Required]
        public int ArtistSongId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public int SongId { get; set; }

        public string ArtistName { get; set; }
        public string SongName { get; set; }
    }
}
