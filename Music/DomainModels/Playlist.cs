using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Playlist
    {
        [Required]
        public int PlaylistId { get; set; }
        [StringLength(30), MinLength(2)]
        public string Title { get; set; }
    }
}
