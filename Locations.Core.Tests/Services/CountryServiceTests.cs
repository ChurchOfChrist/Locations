using System;
using System.Collections.Generic;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;
using Locations.Core.Services;
using NSubstitute;
using NUnit.Framework;
using Should;

namespace Locations.Core.Tests.Services
{
    [TestFixture]
    public class CountryServiceTests
    {
        #region Get country list
        [Test]
        public void GetAllCountriesShouldReturnEmptyIfThereisntAnyCountry()
        {
            var repo = Substitute.For<ICountryRepository>();
            new CountryService(repo).GetAll().Any().ShouldBeFalse();
        }
        [Test]
        public void GetAllCountriesShouldReturnAListOfTheExistingCountries()
        {
            var repo = Substitute.For<ICountryRepository>();
            repo.All().Returns(new List<Country>
            {
                new Country {CreationDate = DateTime.Now, Name = "Dominican Republic"},
                new Country {CreationDate = DateTime.Now, Name = "Dominica"},
                new Country {CreationDate = DateTime.Now, Name = "United States"}
            }.AsEnumerable());
            new CountryService(repo).GetAll().Any().ShouldBeTrue();
        }
        #endregion

    }
}
