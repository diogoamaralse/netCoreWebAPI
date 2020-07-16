using Demo.API.Tables;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Demo.API.Contexts
{
    public class CountryInfoContext : DbContext
    {
        public CountryInfoContext(DbContextOptions<CountryInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(CreateSeedCountries());

            modelBuilder.Entity<OfficialLanguages>()
                .HasData(CreateSeedLanguages());

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<OfficialLanguages> OfficialLanguages { get; set; }

        //protected override void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.
        //}

        private List<OfficialLanguages> CreateSeedLanguages()
        {
            return new List<OfficialLanguages>()
            {
                new OfficialLanguages()
                {
                    Id = 1,
                    LanguageName = "Pashto",
                    CountryId = 1
                },
                new OfficialLanguages()
                {
                    Id = 2,
                    LanguageName = "Dari",
                    CountryId = 1
                },
                new OfficialLanguages()
                {
                    Id = 3,
                    LanguageName = "Albanian",
                    CountryId = 2
                },
                new OfficialLanguages()
                {
                    Id = 4,
                    LanguageName = "Arabic",
                    CountryId = 3
                },
                new OfficialLanguages()
                {
                    Id = 5,
                    LanguageName = "Tamazight",
                    CountryId = 3
                },
            };
        }
        private List<Country> CreateSeedCountries()
        {
            return new List<Country>()
            {
                new Country()
                {
                    Id = 1,
                    Name = "Afghanistan",
                    Population = 38928346,
                    LandArea = 652860,
                    Density = 60,
                },
                new Country()
                {
                    Id = 2,
                    Name = "Albania",
                    Population = 2877797,
                    LandArea = 27400,
                    Density = 105,
                },
                new Country()
                {
                    Id = 3,
                    Name = "Algeria",
                    Population = 43851044,
                    LandArea = 2381740,
                    Density = 18
                }
        };
        }
    }
}
