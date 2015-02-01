using System.Collections.Generic;
using Locations.Core.Entities;

namespace Locations.Core.IRepositories
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetByCountry(int countryId);
    }
}