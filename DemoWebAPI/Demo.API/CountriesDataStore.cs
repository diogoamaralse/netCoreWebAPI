using Demo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API
{
    //It's a Demo -> dummy data
    //On real project I'm using entity framework with a DB
    public class CountriesDataStore
    {
        public static CountriesDataStore Current { get; } = new CountriesDataStore();

        public List<CountryDTO> Countries { get; set; }

        public CountriesDataStore()
        {
            Countries = new List<CountryDTO>()
            {
                new CountryDTO()
                {
                    Id = 1,
                    Name = "Afghanistan",
                    Population = 38928346,
                    LandArea = 652860,
                    Density = 60,
                    OfficialLanguages = new List<OfficialLanguagesByCountryDTO>
                    {
                        new OfficialLanguagesByCountryDTO()
                        {
                            Id = 1,
                            LanguageName = "Pashto"
                        },
                        new OfficialLanguagesByCountryDTO()
                        {
                            Id = 2,
                            LanguageName = "Dari"
                        },
                    }
                },
                new CountryDTO()
                {
                    Id = 2,
                    Name = "Albania",
                    Population = 2877797,
                    LandArea = 27400,
                    Density = 105,
                    OfficialLanguages = new List<OfficialLanguagesByCountryDTO>
                    {
                        new OfficialLanguagesByCountryDTO()
                        {
                            Id = 3,
                            LanguageName = "Albanian"
                        }
                    }
                },
                new CountryDTO()
                {
                    Id = 3,
                    Name = "Algeria",
                    Population = 43851044,
                    LandArea = 2381740,
                    Density = 18,
                    OfficialLanguages = new List<OfficialLanguagesByCountryDTO>
                    {
                        new OfficialLanguagesByCountryDTO()
                        {
                            Id = 4,
                            LanguageName = "Arabic"
                        },
                        new OfficialLanguagesByCountryDTO()
                        {
                            Id = 5,
                            LanguageName = "Tamazight"
                        },
                    }
                }
            };
        }


    }
}
