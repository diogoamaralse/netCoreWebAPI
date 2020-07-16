using Demo.API.Tables;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo.API.Services
{
    public interface ICountryInfoRepository
    {
        IEnumerable<Country> GetCountries();
        Country GetCountry(int countryId, bool includeOfficialLanguages=false);
        IEnumerable<OfficialLanguages> GetOfficialLanguages(int countryid);
        OfficialLanguages GetOfficialLanguagesForCountry(int countryId, int officialLanguageId);
        bool CountryExists(int countryId);

    }
}
