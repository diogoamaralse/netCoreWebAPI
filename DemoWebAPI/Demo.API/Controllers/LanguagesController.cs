using System;
using System.Data;
using System.Linq;
using Demo.API.Domain;
using Demo.API.Models.OfficialLanguages;
using Demo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.API.Controllers
{
    [Route("v1/countries/{countryId}/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILogger<LanguagesController> _logger;
        private readonly IMailServices _mailServices;

        public LanguagesController(ILogger<LanguagesController> logger, IMailServices mailServices)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailServices = mailServices ?? throw new ArgumentNullException(nameof(mailServices));
        }

        [HttpGet("id",Name = "GetLanguages")]
        public IActionResult Get(int countryId, int id)
        {
            try
            {
                var country = CountriesDataStore.Current.Countries.SingleOrDefault(x => x.Id == countryId);

                if (country == null)
                {
                    _logger.LogInformation($"country with id {countryId} wasn't found on endpoint Languagues/GetLanguagues");
                    return NotFound();
                }

                var languagues = country.OfficialLanguages.SingleOrDefault(x => x.Id == id);

                if (languagues == null)
                {
                    _logger.LogInformation($"languagues with id {id} wasn't found on endpoint Languagues/GetLanguagues");

                    return NotFound();
                }

                return Ok(languagues);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Exception Languagues/GetLanguagues: countryid {countryId} and language id {id}", e);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public IActionResult Create(int countryId,[FromBody] OfficialLanguagesByCountryForCreateDTO officialLanguages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = CountriesDataStore.Current.Countries.SingleOrDefault(x => x.Id == countryId);

            if (country == null)
            {
                return NotFound();
            }

            var officialLanguage = Languages.CreateLanguage(officialLanguages);
            
            country.OfficialLanguages.Add(officialLanguage);

            return CreatedAtRoute("GetLanguages", new { countryId = countryId, id = officialLanguage.Id, }, officialLanguage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int countryId, int id ,[FromBody] OfficialLanguagesByCountryForUpdateDTO officialLanguages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = CountriesDataStore.Current.Countries.SingleOrDefault(x => x.Id == countryId);

            if (country == null)
            {
                return NotFound();
            }

            var languaguesStore = country.OfficialLanguages.SingleOrDefault(x => x.Id == id);

            if (languaguesStore == null)
            {
                return NotFound();
            }

            Languages.UpdateLanguage(languaguesStore, officialLanguages);


            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int countryId, int id, [FromBody] JsonPatchDocument<OfficialLanguagesByCountryForUpdateDTO> patchLanguage)
        {

            if (patchLanguage == null)
            {
                return BadRequest();
            }

            var country = CountriesDataStore.Current.Countries.SingleOrDefault(x => x.Id == countryId);

            if (country == null)
            {
                return NotFound();
            }

            var languaguesStore = country.OfficialLanguages.SingleOrDefault(x => x.Id == id);

            if (languaguesStore == null)
            {
                return NotFound();
            }

            var languaguesToPatch = new OfficialLanguagesByCountryForUpdateDTO()
            {
                LanguageName = languaguesStore.LanguageName
            };

            patchLanguage.ApplyTo(languaguesToPatch, ModelState);

            var isValid = TryValidateModel(languaguesToPatch);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            
            Languages.UpdateLanguage(languaguesStore, languaguesToPatch);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int countryId, int id)
        {

            var country = CountriesDataStore.Current.Countries.SingleOrDefault(x => x.Id == countryId);

            if (country == null)
            {
                return NotFound();
            }

            var languaguesStore = country.OfficialLanguages.SingleOrDefault(x => x.Id == id);

            if (languaguesStore == null)
            {
                return NotFound();
            }

            country.OfficialLanguages.Remove(languaguesStore);

            _mailServices.Send($"Language Deleted.",
                $"Languages {languaguesStore.LanguageName} " +
                $"with id {languaguesStore.Id}");

            return NoContent();
        }



    }
}
