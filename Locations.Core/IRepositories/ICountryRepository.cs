using System.Collections.Generic;
using Locations.Core.Entities;

namespace Locations.Core.IRepositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> All();
        Country Add(Country entity);
        Country GetById(int id);
        IEnumerable<Country> GetByName(string name);
        
    }
}