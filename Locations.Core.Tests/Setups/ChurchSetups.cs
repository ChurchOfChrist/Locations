using System.Linq;
using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;
using NSubstitute;

namespace Locations.Core.Tests.Setups
{
    public static class ChurchSetups
    {
        public static void DefaultList(this IChurchRepository repo)
        {
            repo.With(EntitySeed.DefaultChurches);
            repo.GetByCity(Arg.Any<int>()).Returns(args => EntitySeed.DefaultChurches.Where(c => c.CityId == (int)args[0]));
            repo.GetByCountry(Arg.Any<int>()).Returns(args => EntitySeed.DefaultCitiesWithCountries().Where(c => c.City.CountryId == (int)args[0]));
            repo.GetByCityAndSector(0, "any")
                .ReturnsForAnyArgs(
                    args =>
                        EntitySeed.DefaultChurches.Where(
                            c => c.CityId == (int) args[0] && c.Sector.Contains(args[1].ToString())));
        }



    }
}