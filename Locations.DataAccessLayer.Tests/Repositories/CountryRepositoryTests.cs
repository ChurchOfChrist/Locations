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
    public class CountryRepositoryTests
    {
        private readonly ICountryRepository _repository;
        public CountryRepositoryTests()
        {
            //Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            var connection = Effort.DbConnectionFactory.CreateTransient();
            var context = new ChurchDb(connection);
            //For the these tests we will add this countries
            context.Countries.AddRange(new List<Country>
            {
                new Country {CreationDate = DateTime.Now, Name = "Dominican Republic"},
                new Country {CreationDate = DateTime.Now, Name = "Dominica"},
                new Country {CreationDate = DateTime.Now, Name = "United States"}
            });
            context.SaveChanges();
            _repository = new CountryRepository(context);
        }
        [Test]
        public void GetByNameShouldReturnNothingIfTheNameDidntMatchAnyName()
        {
            const string name = "UnexistingName";
            _repository.GetByName(name).Any().ShouldBeFalse();
        }

        [Test]
        public void GetByNameShouldReturnAListIfAnyNameMatch()
        {
            const string name = "United";
            _repository.GetByName(name).Any().ShouldBeTrue();
        }

        [Test]
        public void GetByNameShouldReturnAllTheMatchingCountries()
        {
            const string name = "Domini";
            _repository.GetByName(name).ToList().ForEach(c => c.Name.ShouldContain(name));
        }

    }
}
