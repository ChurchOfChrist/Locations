using System.Collections.Generic;
using Locations.Core.Entities;

namespace Locations.Core.IRepositories
{
    public interface IChurchRepository
    {
        IEnumerable<Church> All();
        Church Add(Church entity);
        Church GetById(int id);
        IEnumerable<Church> GetByCountry(int countryId);
        IEnumerable<Church> GetByCityAndSector(int cityId, string sector);
        IEnumerable<Church> GetByCity(int cityId);
    }
}