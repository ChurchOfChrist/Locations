using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.DataAccessLayer.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context):base(context)
        {
        }

        public IEnumerable<Country> GetByName(string name)
        {
            return EntitySet.Where(c => c.Name.Contains(name));
        }
    }
}
