using System;
using System.Collections.Generic;
using Locations.Core.Entities;
using Locations.DataAccessLayer.Context;

namespace Locations.DataAccessLayer.Tests.Setups
{
    public static class ContextSetups
    {
        public static void DefaultCountries(this ChurchDb context)
        {
            context.Countries.AddRange(new List<Country>
            {
                new Country {CreationDate = DateTime.Now, Name = "Dominican Republic"},
                new Country {CreationDate = DateTime.Now, Name = "United States"},
                new Country {CreationDate = DateTime.Now, Name = "Dominica"},
                
            });
            context.SaveChanges();
        }

        public static void DefaultCities(this ChurchDb context)
        {
            context.Cities.AddRange(new List<City>
            {
                new City {CreationDate = DateTime.Now, Name = "Santo Domingo", CountryId = 1},
                new City {CreationDate = DateTime.Now, Name = "Santiago", CountryId = 2},
                new City {CreationDate = DateTime.Now, Name = "New York", CountryId = 3},
            });
            context.SaveChanges(); 
        }

        public static void DefaultChurches(this ChurchDb context)
        {
            context.Churches.AddRange(new List<Church>
            {
                new Church {Description = "First Church, First City", CityId = 1, CreationDate = DateTime.Now},
                new Church {Description = "Second Church, First City", CityId = 1, CreationDate = DateTime.Now},
                new Church {Description = "Third Church, First City", CityId = 1, CreationDate = DateTime.Now},
                new Church {Description = "First Church, Second City", CityId = 2, CreationDate = DateTime.Now},
                new Church {Description = "Second Church, Second City", CityId = 2, CreationDate = DateTime.Now},
                new Church {Description = "Third Church, Second City", CityId = 2, CreationDate = DateTime.Now},
                new Church {Description = "First Church, Third City", CityId = 3, CreationDate = DateTime.Now},
                new Church {Description = "Second Church, Third City", CityId = 3, CreationDate = DateTime.Now},
                new Church {Description = "Third Church, Third City", CityId = 2, CreationDate = DateTime.Now}

            });
            context.SaveChanges();
        }
    }
}