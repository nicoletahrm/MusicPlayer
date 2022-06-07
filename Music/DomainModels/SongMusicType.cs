using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class SongMusicType
    {

        [Required]
        public int SongMusicTypeId { get; set; }
        [Required]
        public int SongId { get; set; }

        [Required]
        public int MusicTypeId { get; set; }
        public string SongName { get; set; }
        public string MusicTypeName { get; set; }
    }
}
