using System.Collections.Generic;
using Locations.Core.Entities;

namespace Locations.Core.IRepositories
{
    public interface IChurchRepository : IRepository<Church>
    {
        IEnumerable<Church> GetByCountry(int countryId);
        IEnumerable<Church> GetByCityAndSector(int cityId, string sector);
        IEnumerable<Church> GetByCity(int cityId);
    }
}