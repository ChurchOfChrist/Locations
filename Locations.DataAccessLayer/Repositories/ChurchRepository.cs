using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.DataAccessLayer.Repositories
{
    public class ChurchRepository : Repository<Church>, IChurchRepository
    {
        public ChurchRepository(DbContext context) : base(context) { }
        /// <summary>
        /// This gets all the churches that belongs a specific country
        /// </summary>
        /// <param name="countryId">The Id of the country</param>
        /// <returns>A list of Churches</returns>
        public IEnumerable<Church> GetByCountry(int countryId)
        {
            return EntitySet.Where(c => c.City.CountryId == countryId);
        }

        /// <summary>
        /// All the churches that belongs to a specific country and 
        /// that its sector con match
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="sector">the name, cause this can vary a lot, that's why we're saving like a string</param>
        /// <returns>List of all matching churches</returns>
        public IEnumerable<Church> GetByCityAndSector(int cityId, string sector)
        {
            return EntitySet.Where(c => c.CityId == cityId && c.Sector.Contains(sector));
        }

        public IEnumerable<Church> GetByCity(int cityId)
        {
            return EntitySet.Where(c => c.CityId == cityId);
        }
    }
}
