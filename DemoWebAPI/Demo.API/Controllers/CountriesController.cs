using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CountriesDataStore.Current.Countries);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var country = CountriesDataStore.Current.Countries.SingleOrDefault(x => x.Id == id);

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
