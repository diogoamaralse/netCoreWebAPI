using System.Collections.Generic;

namespace Demo.API.Models
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int LandArea { get; set; }
        public int Density { get; set; }

        public int NrOfficialLanguages { 
            get 
            {
                return OfficialLanguages.Count;
            } 
        }


        public ICollection<OfficialLanguagesByCountryDTO> OfficialLanguages { get; set; } = new List<OfficialLanguagesByCountryDTO>();
    }
}
