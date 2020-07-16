using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.API.Tables
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int Population { get; set; }
        public int LandArea { get; set; }
        public int Density { get; set; }

        public ICollection<OfficialLanguages> OfficialLanguages { get; set; } = new List<OfficialLanguages>();

    }
}
