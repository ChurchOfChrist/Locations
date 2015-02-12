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
    public class CountryServiceTests
    {
        private ICountryRepository Repo { get; set; }

        #region Get country list

        [SetUp]
        public void Setups()
        {
            Repo = Substitute.For<ICountryRepository>();
        }

        [Test]
        public void GetAllCountriesShouldReturnEmptyIfThereisntAnyCountry()
        {
            new CountryService(Repo).GetAll().Any().ShouldBeFalse();
        }

        [Test]
        public void GetAllCountriesShouldReturnAListOfTheExistingCountries()
        {
            Repo.DefaultList();
            new CountryService(Repo).GetAll().Any().ShouldBeTrue();
        }

        #endregion
    }
}
