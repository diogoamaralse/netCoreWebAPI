using Demo.API.Tables;
using Microsoft.EntityFrameworkCore;

namespace Demo.API.Contexts
{
    public class CountryInfoContext : DbContext
    {
        public CountryInfoContext(DbContextOptions<CountryInfoContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<OfficialLanguages> OfficialLanguages { get; set; }

        //protected override void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.
        //}
    }
}
