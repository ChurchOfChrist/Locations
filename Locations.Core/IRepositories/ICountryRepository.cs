using System.Collections.Generic;
using Locations.Core.Entities;

namespace Locations.Core.IRepositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        IEnumerable<Country> GetByName(string name);
    }
}