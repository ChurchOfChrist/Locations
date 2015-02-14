using System;
using System.Collections.Generic;
using System.Linq;
using Locations.Core.Entities;

namespace Locations.DataAccessLayer.Context
{
    public static class EntitySeed
    {
        public static Church[] DefaultChurches = {
            new Church {Description = "First Church, First City", Sector  = "Existing Sector", CityId = 1, CreationDate = DateTime.Now},
            new Church {Description = "Second Church, First City",Sector  = "Existing Sector",  CityId = 1, CreationDate = DateTime.Now},
            new Church {Description = "Third Church, First City",Sector  = "Existing Sector",   CityId = 1, CreationDate = DateTime.Now},
            new Church {Description = "First Church, Second City", Sector  = "Existing Sector", CityId = 2, CreationDate = DateTime.Now},
            new Church {Description = "Second Church, Second City",Sector  = "Existing Sector", CityId = 2, CreationDate = DateTime.Now},
            new Church {Description = "Third Church, Second City", Sector  = "Existing Sector", CityId = 2, CreationDate = DateTime.Now},
            new Church {Description = "First Church, Third City", Sector  = "Existing Sector",  CityId = 3, CreationDate = DateTime.Now},
            new Church {Description = "Second Church, Third City", Sector  = "Existing Sector", CityId = 3, CreationDate = DateTime.Now},
            new Church {Description = "Third Church, Third City", Sector  = "Existing Sector",  CityId = 2, CreationDate = DateTime.Now}
        };

        public static City[] DefaultCities =
        {

            new City {Id = 1, CountryId = 1, CreationDate = DateTime.Now, Name = "Santo Domingo"},
            new City {Id = 2, CountryId = 1, CreationDate = DateTime.Now, Name = "Santiago"},
            new City {Id = 3, CountryId = 1, CreationDate = DateTime.Now, Name = "La Romana"},
            new City {Id = 4, CountryId = 1, CreationDate = DateTime.Now, Name = "Puerto Plata"},
            new City {Id = 5, CountryId = 1, CreationDate = DateTime.Now, Name = "San Juan"}

        };

        public static Country[] DefaultCountries =
        {
            new Country {Id = 1, CreationDate = DateTime.Now, Name = "Dominican Republic"},
            new Country {Id = 2, CreationDate = DateTime.Now, Name = "Dominica"},
            new Country {Id = 3, CreationDate = DateTime.Now, Name = "United States"}
        };

        public static List<Church> DefaultCitiesWithCountries()
        {
            var result = DefaultChurches.ToList();
            result.ForEach(n => n.City = DefaultCities.FirstOrDefault(c => c.Id == n.CityId));
            return result;
        }
    }
}
