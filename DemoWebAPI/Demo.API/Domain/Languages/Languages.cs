using Demo.API.Models;
using Demo.API.Models.OfficialLanguages;
using System.Linq;

namespace Demo.API.Domain
{
    public static class Languages
    {

        public static OfficialLanguagesByCountryDTO CreateLanguage(OfficialLanguagesByCountryForCreateDTO officialLanguages)
        {
            var maxofficialLanguageId = CountriesDataStore.Current.Countries
                                        .SelectMany(x => x.OfficialLanguages)
                                        .Max(z => z.Id);

            return new OfficialLanguagesByCountryDTO()
            {
                Id = ++maxofficialLanguageId,
                LanguageName = officialLanguages.LanguageName
            };
        }

        public static OfficialLanguagesByCountryDTO UpdateLanguage(OfficialLanguagesByCountryDTO languaguesStore, OfficialLanguagesByCountryForUpdateDTO officialLanguages)
        {
            languaguesStore.LanguageName = officialLanguages.LanguageName;

            return languaguesStore;
        }
    }
}
