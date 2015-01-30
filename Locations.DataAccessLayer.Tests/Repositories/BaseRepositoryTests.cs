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
    /// <summary>
    /// In other to tests the methods shared by the repositories
    /// in just one place and avoid unnecesarry repetitions of the code
    /// Let's create this testclass to 'test' these shared methods
    /// </summary>
    [TestFixture]
    public class BaseRepositoryTests
    {
        /// <summary>
        /// We could use any entity to test this repository
        /// But now lets use Country, and all the repositories should have the same behavior
        /// </summary>
        private readonly IRepository<Country> _repository;
        /// <summary>
        /// Let's use this list to test if the All method is working as expected
        /// </summary>
        private readonly List<Country> _countries = new List<Country>
        {
          new Country {CreationDate = DateTime.Now, Name = "Dominica"},
                new Country {CreationDate = DateTime.Now, Name = "United States"}  
        };

        public BaseRepositoryTests()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            var context = new ChurchDb(connection);
            context.Countries.AddRange(_countries);
            context.SaveChanges();
            _repository = new Repository<Country>(context);
        }
        [Test]
        public void TheAddMethodShouldReturnTheEntitySaved()
        {
            var entity = new Country
            {
                Name = "Dominican Republic"
            };
            _repository.Add(entity);
            _repository.SaveChanges();
            entity.Id.ShouldBeGreaterThan(0);
        }

        [Test]
        public void AllShouldReturnAlistOfAllTheEntitiesIfIthasAny()
        {
          _repository.All().ToList().ShouldEqual(_countries);
        }
        [Test]
        public void GetByIdShouldReturnAnEntityWithTheIdRequested()
        {
            const int id = 1;
            _repository.GetById(id).Id.ShouldEqual(id);
        }

        [Test]
        public void GetByIdShouldReturnNullIfTheEntityWithTheIdWasntFound()
        {
            const int id = 0;
            _repository.GetById(id).ShouldBeNull();
        }


    }
}
