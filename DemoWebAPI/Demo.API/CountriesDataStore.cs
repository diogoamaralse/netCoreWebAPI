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
        public static CountriesDataStore Current { get; } //= new CountriesDataStore();

        public List<CountryDTO> Countries { get; set; }

        public CountriesDataStore()
        {
           
        }


    }
}
