using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class Artist
    {
        [Required]
        public int ArtistId { get; set; }

        [StringLength(15), MinLength(2)]
        public string LastName { get; set; }

        [StringLength(15), MinLength(0)]
        public string FirstName { get; set; }

        [StringLength(15), MinLength(2)]
        public string Nationality { get; set; }

        [StringLength(2), MinLength(1)]
        public string Sex { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
