using System;
using System.Collections.Generic;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;
using Locations.DataAccessLayer.Repositories;
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
            context.Countries.AddRange(new List<Country>
            {
                new Country {CreationDate = DateTime.Now, Name = "Dominican Republic"},
                new Country {CreationDate = DateTime.Now, Name = "Dominica"},
                new Country {CreationDate = DateTime.Now, Name = "United States"}
            });
            context.SaveChanges();
            context.Churches.AddRange(new List<Church>
            {
                new Church {Description = "First Church", CountryId = 1, CreationDate = DateTime.Now},
                new Church {Description = "Second Church", CountryId = 1, CreationDate = DateTime.Now},
                new Church {Description = "Another Country Church", CountryId = 2, CreationDate = DateTime.Now}
            });
            context.SaveChanges();
            _repository = new ChurchRepository(context);
        }
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
            _repository.GetByCountry(countryId).ToList().ForEach(c => c.CountryId.ShouldEqual(countryId));
        }
        [Test]
        public void GetByCountryShouldReturnAnEmptyListIfTheCountryDoesntHaveAnyChurch()
        {
            const int countryId = 1;
            const string sectorName = "Sant";
            _repository.GetByCountryAndSector(countryId, sectorName).ToList().ForEach(c =>
            {
                c.CountryId.ShouldEqual(countryId);
                c.Sector.ShouldContain(sectorName);
            });
        }
    }
}
