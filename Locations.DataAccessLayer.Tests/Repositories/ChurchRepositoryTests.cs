using System.Linq;
using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;
using Locations.DataAccessLayer.Repositories;
using Locations.DataAccessLayer.Tests.Setups;
using NUnit.Framework;
using Should;

namespace Locations.DataAccessLayer.Tests.Repositories
{

    [TestFixture]
    public class ChurchRepositoryTests
    {
        private readonly IChurchRepository _repository;
        public ChurchRepositoryTests()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            var context = new ChurchDb(connection);
            context.DefaultCountries();
            context.DefaultCities();
            context.DefaultChurches();
            context.DefaultChurches();
            _repository = new ChurchRepository(context);
        }
        #region GetByCountry
        [Test]
        public void GetByCountryShouldReturnAListWhenChurchesBelongsToThatCountry()
        {
            const int countryId = 1;
            _repository.GetByCountry(countryId).ShouldNotBeEmpty();
        }
        [Test]
        public void GetByCountryShouldReturnNothingWhenChurchesBelongsToItCountry()
        {
            const int countryId = 5;
            _repository.GetByCountry(countryId).ShouldBeEmpty();
        }
        [Test]
        public void GetByCountryShouldReturnAListWithOnlyChurchesOfThatCountry()
        {
            const int countryId = 1;
            _repository.GetByCountry(countryId).ToList().ForEach(c => c.City.CountryId.ShouldEqual(countryId));
        } 
        #endregion
        #region GetByCity
        [Test]
        public void GetByCityShouldReturnAListWhenChurchesBelongsToThatCity()
        {
            const int cityId = 1;
            _repository.GetByCity(cityId).ShouldNotBeEmpty();
        }
        [Test]
        public void GetByCityShouldReturnNothingWhenChurchesBelongsToItCity()
        {
            const int cityId = 0;
            _repository.GetByCity(cityId).ShouldBeEmpty();
        }
        [Test]
        public void GetByCityShouldReturnAListWithOnlyChurchesOfThatCity()
        {
            const int cityId = 1;
            _repository.GetByCity(cityId).ToList().Any(c => c.CityId != cityId).ShouldBeFalse();
        }
        #endregion

        #region GetByCityAndSector
        [Test]
        public void GetByCityShouldReturnAnEmptyListIfTheCountryDoesntHaveAnyChurch()
        {
            const int countryId = 1;
            const string sectorName = "Sant";
            _repository.GetByCityAndSector(countryId, sectorName).ToList().ForEach(c =>
            {
                c.City.CountryId.ShouldEqual(countryId);
                c.Sector.ShouldContain(sectorName);
            });
        }
        #endregion

    }
}
