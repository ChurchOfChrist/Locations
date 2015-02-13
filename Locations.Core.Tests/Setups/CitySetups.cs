using System.Linq;
using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;
using NSubstitute;

namespace Locations.Core.Tests.Setups
{
    public static class CitySetups
    {
        public static void DefaultList(this ICityRepository repo)
        {
            repo.With(EntitySeed.DefaultCities);
            repo.GetByCountry(Arg.Any<int>())
                .Returns(info => EntitySeed.DefaultCities.Where(city => city.CountryId == (int) info[0]));
        }
    }
}