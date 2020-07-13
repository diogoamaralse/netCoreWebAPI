using System.ComponentModel.DataAnnotations;

namespace Demo.API.Models.OfficialLanguages
{
    public class OfficialLanguagesByCountryForCreateDTO
    {
        [Required(ErrorMessage = "You should provide a language name value.")]
        [MaxLength(100)]
        public string LanguageName { get; set; }
    }
}
