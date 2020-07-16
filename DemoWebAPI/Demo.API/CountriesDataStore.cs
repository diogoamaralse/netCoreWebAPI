using Demo.API.Models;
using System.Collections.Generic;

namespace Demo.API
{
    //It's a Demo -> dummy data
    //On real project I'm using entity framework with a DB
    public class CountriesDataStore
    {
        public static CountriesDataStore Current { get; } //= new CountriesDataStore();

        public List<CountryDTO> Countries { get; set; }

    }
}
