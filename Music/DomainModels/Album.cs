using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Album
    {
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public int ArtistId { get; set; }

        [StringLength(150), MinLength(1)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        [StringLength(150), MinLength(2)]
        public string RecordLabelName { get; set; }

        public string ArtistName { get; set; }
    }
}
