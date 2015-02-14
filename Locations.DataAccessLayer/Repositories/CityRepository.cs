using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.DataAccessLayer.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DbContext context) : base(context) { }
        public IEnumerable<City> GetByCountry(int countryId)
        {
            return EntitySet.Where(c => c.CountryId == countryId);
        }
    }
}