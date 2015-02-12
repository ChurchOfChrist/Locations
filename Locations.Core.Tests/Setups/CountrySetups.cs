using System;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.Core.Tests.Setups
{
    public static class CountrySetups
    {
        public static void DefaultList(this ICountryRepository repo)
        {
            repo.With(
                new Country { Id = 1, CreationDate = DateTime.Now, Name = "Dominican Republic" },
                new Country { Id = 2, CreationDate = DateTime.Now, Name = "Dominica" },
                new Country { Id = 3, CreationDate = DateTime.Now, Name = "United States" });
        }
    }
}