using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.DataAccessLayer.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context):base(context) {}
        /// <summary>
        /// All the countries that match with the name
        /// </summary>
        /// <param name="name">Part or the complete name of a country</param>
        /// <returns>List of the matching countries</returns>
        public IEnumerable<Country> GetByName(string name)
        {
            return EntitySet.Where(c => c.Name.Contains(name));
        }
    }
}
