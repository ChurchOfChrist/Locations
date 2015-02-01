using System.Data.Entity;
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
    public class CityRepositoryTests
    {
        private ICityRepository Repository { get; set; }
        private ChurchDb _context;

        [SetUp]
        public void Setups()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            _context = new ChurchDb(connection);
            Repository = new CityRepository(_context);
        }
        [Test]
        public void GetByCountryShouldReturnEmptyWhenACountryDoesNotHaveAnyCity()
        {
            const int countryId = 1;
            Repository.GetByCountry(countryId).Any().ShouldBeFalse();
        }

        [Test]
        public void GetByCountryShouldReturnAListOfTheCitiesThatBelongsToTheGivenCountry()
        {
            const int countryId = 1;
            _context.DefaultCountries();
            _context.DefaultCities();
            var cities = Repository.GetByCountry(countryId).ToList();
            cities.Any().ShouldBeTrue();
            cities.Any(c => c.CountryId != countryId).ShouldBeFalse();
        }
    }
}
