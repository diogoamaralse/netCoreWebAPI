using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.API.Tables
{
    public class OfficialLanguages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string LanguageName { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
