using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;

namespace Locations.Core.Tests.Setups
{
    public static class CountrySetups
    {
        public static void DefaultList(this ICountryRepository repo)
        {
            repo.With(EntitySeed.DefaultCountries);
        }
    }
}