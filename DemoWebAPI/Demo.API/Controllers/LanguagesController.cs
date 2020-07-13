using System.Linq;
using Demo.API.Domain;
using Demo.API.Models.OfficialLanguages;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("v1/countries/{countryId}/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        [HttpGet("id",Name = "GetLanguages")]
        public IActionResult Get(int countryId, int id)
        {
            var country = CountriesDataStore.Current.Countries.SingleOrDefault(x => x.Id == countryId);

            if (country == null)
            {
                return NotFound();
            }

            var languagues = country.OfficialLanguages.SingleOrDefault(x => x.Id == id);

            if (languagues == null)
            {
                return NotFound();
            }

            return Ok(languagues);
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

            return NoContent();
        }



    }
}
