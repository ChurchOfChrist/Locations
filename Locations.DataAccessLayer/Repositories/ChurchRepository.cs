using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.DataAccessLayer.Repositories
{
    public class ChurchRepository : Repository<Church>, IChurchRepository
    {
        public ChurchRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Church> GetByCountry(int countryId)
        {
            return EntitySet.Where(c => c.CountryId == countryId);
        }

        public IEnumerable<Church> GetByCountryAndSector(int countryId, string sector)
        {
            return EntitySet.Where(c => c.CountryId == countryId && c.Sector.Contains(sector));
        }
    }
}
