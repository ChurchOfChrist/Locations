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
    public class ChurchServiceTests
    {
        private IChurchRepository Repository { get; set; }
        private ChurchService Service { get; set; }
        [SetUp]
        public void Setups()
        {
            Repository = Substitute.For<IChurchRepository>();
            Repository.DefaultList();
            Service = new ChurchService(Repository);
        }

        #region GetByCountry
        [Test]
        public void GetByCountryShouldReturnAListWhenChurchesBelongsToThatCountry()
        {
            const int countryId = 1;
            Service.GetByCountry(countryId).ShouldNotBeEmpty();
        }
        [Test]
        public void GetByCountryShouldReturnNothingWhenChurchesBelongsToThatCountry()
        {
            const int countryId = 5;
            Service.GetByCountry(countryId).ShouldBeEmpty();
        }
        [Test]
        public void GetByCountryShouldReturnAListWithOnlyChurchesOfThatCountry()
        {
            const int countryId = 1;
            Service.GetByCountry(countryId).All(c => c.City.CountryId == countryId).ShouldBeTrue();
        }
        #endregion

        #region GetByCity
        [Test]
        public void GetByCityShouldReturnAListWhenChurchesBelongsToThatCity()
        {
            const int cityId = 1;
            var result = 
            Service.GetByCity(cityId);
            result.ShouldNotBeEmpty();
        }
        [Test]
        public void GetByCityShouldReturnNothingWhenChurchesBelongsToItCity()
        {
            const int cityId = 0;
            Service.GetByCity(cityId).ShouldBeEmpty();
        }
        [Test]
        public void GetByCityShouldReturnAListWithOnlyChurchesOfThatCity()
        {
            const int cityId = 1;
            Service.GetByCity(cityId).ToList().Any(c => c.CityId != cityId).ShouldBeFalse();
        }
        #endregion

        #region GetByCityAndSector
        [Test]
        public void GetByCityShouldReturnAnEmptyListIfTheCountryDoesntHaveAnyChurch()
        {
            const int cityId = 1;
            const string sectorName = "Los Frailes";
            Service.GetByCityAndSector(cityId, sectorName).ShouldBeEmpty();
        }
        #endregion


    }
}
