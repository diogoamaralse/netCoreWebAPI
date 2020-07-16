using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Demo.API.Services;
using System.Collections.Generic;
using Demo.API.Models;

namespace Demo.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryInfoRepository _countryInfoRepository;
        public CountriesController(ICountryInfoRepository countryInfoRepository)
        {
            _countryInfoRepository = countryInfoRepository ??
                throw new ArgumentNullException(nameof(countryInfoRepository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var countriesEntities = _countryInfoRepository.GetCountries();

            var results = new List<CountriesWithoutOfficialLanguagesDTO>();

                foreach (var _countryEntity in countriesEntities)
                {
                    results.Add(new CountriesWithoutOfficialLanguagesDTO
                    {
                        Id = _countryEntity.Id,
                        Name = _countryEntity.Name,
                        Density = _countryEntity.Density,
                        LandArea = _countryEntity.LandArea,
                        Population = _countryEntity.Population
                    });
                }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, bool languages = false)
        {
            try
            {
                var country = _countryInfoRepository.GetCountry(id, languages);

  
                if (country == null)
                {
                    return NotFound();
                }

                if (languages)
                {
                    var countryResults = new CountryDTO()
                    {
                        Id = country.Id,
                        Name = country.Name,
                        Density = country.Density,
                        LandArea = country.LandArea,
                        Population = country.Population
                    };

                    foreach (var lang in country.OfficialLanguages)
                    {
                        countryResults.OfficialLanguages.Add(
                            new OfficialLanguagesByCountryDTO()
                            {
                                Id = lang.Id,
                                LanguageName = lang.LanguageName
                            });
                    }
                    return Ok(countryResults);
                }
                else
                {
                    var countryResults = new CountryDTO()
                    {
                        Id = country.Id,
                        Name = country.Name,
                        Density = country.Density,
                        LandArea = country.LandArea,
                        Population = country.Population
                    };

                    return Ok(countryResults);
                }
               

             
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
