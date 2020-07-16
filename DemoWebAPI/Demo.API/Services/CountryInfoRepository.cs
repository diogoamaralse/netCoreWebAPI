using Demo.API.Contexts;
using Demo.API.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.API.Services
{
    public class CountryInfoRepository : ICountryInfoRepository
    {
        private CountryInfoContext _context;

        public CountryInfoRepository(CountryInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.OrderBy(x => x.Name).ToList();
        }

        public Country GetCountry(int countryId, bool includeOfficialLanguages=false)
        {
            if (includeOfficialLanguages)
            {
                return _context.Countries
                               .Include(x => x.OfficialLanguages)
                               .Where(x => x.Id == countryId)
                               .FirstOrDefault();

            }

            return _context.Countries
               .Where(x => x.Id == countryId)
               .FirstOrDefault();
        }

        public IEnumerable<OfficialLanguages> GetOfficialLanguages(int countryid)
        {
            return _context.OfficialLanguages
                           .Where(x=>x.CountryId == countryid)
                           .OrderBy(x => x.LanguageName).ToList();
        }

        public OfficialLanguages GetOfficialLanguagesForCountry(int countryId, int officialLanguageId)
        {
            return _context.OfficialLanguages
                 .Where(x => x.CountryId == countryId && x.Id == officialLanguageId)
                 .FirstOrDefault();
        }

        public bool CountryExists(int countryId)
        {
            return _context.Countries.Any(x => x.Id == countryId);
        }
    }
}
