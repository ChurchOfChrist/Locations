using System;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.Core.Tests.Setups
{
    public static class CitySetups
    {
        public static void DefaultList(this ICityRepository repo)
        {
            repo.With(
                new City {Id = 1, CountryId = 1, CreationDate = DateTime.Now, Name = "Santo Domingo"},
                new City {Id = 2, CountryId = 1, CreationDate = DateTime.Now, Name = "Santiago"},
                new City {Id = 3, CountryId = 1, CreationDate = DateTime.Now, Name = "La Romana"},
                new City {Id = 4, CountryId = 1, CreationDate = DateTime.Now, Name = "Puerto Plata"},
                new City {Id = 5, CountryId = 1, CreationDate = DateTime.Now, Name = "San Juan"}
                );
        }
    }
}