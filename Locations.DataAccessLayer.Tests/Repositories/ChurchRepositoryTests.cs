using Effort;
using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;
using Locations.DataAccessLayer.Repositories;
using Locations.DataAccessLayer.Tests.Setups;
using NUnit.Framework;

namespace Locations.DataAccessLayer.Tests.Repositories
{

    [TestFixture]
    public class ChurchRepositoryTests
    {
        private readonly IChurchRepository _repository;
        public ChurchRepositoryTests()
        {
            var connection = DbConnectionFactory.CreateTransient();
            var context = new ChurchDb(connection);
            context.DefaultCountries();
            context.DefaultCities();
            context.DefaultChurches();
            _repository = new ChurchRepository(context);
        }
    }
}
