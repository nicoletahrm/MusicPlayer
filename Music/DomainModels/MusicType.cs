using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class MusicType
    {
        [Required]
        public int MusicTypeId { get; set; }
        [StringLength(15), MinLength(2)]
        public string Genre { get; set; }
    }
}
