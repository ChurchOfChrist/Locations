using System.Linq;
using Locations.Core.IRepositories;
using Locations.Core.Services;
using Locations.Core.Tests.Setups;
using NSubstitute;
using NUnit.Framework;
using Should;

namespace Locations.Core.Tests.Services
{
    [TestFixture]
    public class CityServiceTests
    {
        private ICityRepository Repository { get; set; }

        [SetUp]
        public void Setups()
        {
            Repository = Substitute.For<ICityRepository>();
        }

        [Test]
        public void GetCitiesByCountryIdShouldReturnAllTheCitiesOfThatCountry()
        {
            Repository.DefaultList();
            const int countryId = 1;
            new CityService(Repository).GetByCountry(countryId).All(c => c.CountryId == countryId).ShouldBeTrue();
        }
        [Test]
        public void GetCitiesByCountryIdShouldReturnEmptyIfTheCountryDoesntHaveAnyCity()
        {
            const int countryId = 1;
            new CityService(Repository).GetByCountry(countryId).ShouldBeEmpty();
        }

    }
}
