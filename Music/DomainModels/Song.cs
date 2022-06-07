using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Song
    {
        [Required]
        public int SongId { get; set; }

        [StringLength(150), MinLength(1)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public int Likes { get; set; }
    }
}
