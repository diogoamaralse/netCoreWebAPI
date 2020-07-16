using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Models
{
    public class CountriesWithoutOfficialLanguagesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int LandArea { get; set; }
        public int Density { get; set; }
    }
}
