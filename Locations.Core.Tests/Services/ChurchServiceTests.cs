using System.Linq;
using Locations.Core.Helpers;
using Locations.Core.IRepositories;
using Locations.Core.Services;
using Locations.Core.Tests.Setups;
using Locations.Core.ViewModels;
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
            Service.GetByCountry(countryId).Any().ShouldBeTrue();
        }
        [Test]
        public void GetByCountryShouldReturnNothingWhenChurchesBelongsToThatCountry()
        {
            const int countryId = 5;
            Service.GetByCountry(countryId).Any().ShouldBeFalse();
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
            result.Any().ShouldBeTrue();
        }
        [Test]
        public void GetByCityShouldReturnNothingWhenChurchesBelongsToItCity()
        {
            const int cityId = 0;
            Service.GetByCity(cityId).Any().ShouldBeFalse();
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
        public void GetByCityAndSectorShouldReturnAnEmptyListIfItDoesntHaveAnyChurchMatches()
        {
            const int cityId = 1;
            const string sectorName = "Los Frailes";
            Service.GetByCityAndSector(cityId, sectorName).ShouldBeEmpty();
        }
        [Test]
        public void GetByCityAndSectorShouldReturnListIfItHaveAnyChurchMatches()
        {
            const int cityId = 1;
            const string sectorName = "Existing Sector";
            Service.GetByCityAndSector(cityId, sectorName).ShouldNotBeEmpty();
        }
        #endregion

        #region Add new church

        [Test]
        public void ChurchShouldNotBeAddedIfTheSectorIsNullOrEmpty()
        {
            var church = new ChurchViewModel
            {
                CityId = 1,
                Description = "Any Description",
                Latitude = 18.473123M,
                Longitude = -69.809590M,
                Preacher = "Any Preacher",
                PhoneNumber = "809 - Any number"
            };
            Service.Add(church).ShouldBeFalse();
        }
        [Test]
        public void ChurchShouldNotBeAddedIfTheCityDoesNotExist()
        {
            var church = new ChurchViewModel
            {
                CityId = 0,
                Description = "Any Description",
                Latitude = 18.473123M,
                Longitude = -69.809590M,
                Preacher = "Any Preacher",
                PhoneNumber = "809 - Any number",
                Sector = "Any sector"
            };
            Service.Add(church).ShouldBeFalse();
        }
        [Test]
        public void ChurchShouldNotBeAddedIfPreacherIsNullOrEmpty()
        {
            var church = new ChurchViewModel
            {
                CityId = 1,
                Description = "Any Description",
                Latitude = 18.473123M,
                Longitude = -69.809590M,
                PhoneNumber = "809 - Any number",
                Sector = "Any sector",
                Location = GeoHelper.FromLatLng(18.66966526847465, -69.8675537109375)
            };
            Service.Add(church).ShouldBeFalse();
        }
        [Test]
        public void ChurchShouldNotBeAddedIfPhoneNumberIsNullOrEmpty()
        {
            var church = new ChurchViewModel
            {
                CityId = 1,
                Description = "Any Description",
                Latitude = 18.473123M,
                Longitude = -69.809590M,
                Preacher = "Any Preacher",
                Sector = "Any sector",
            };
            Service.Add(church).ShouldBeFalse();
        }

        [Test]
        public void ChurchShouldBeAddedContainsAsectorPreacherAndPhoneNumber()
        {
            var church = new ChurchViewModel
            {
                CityId = 1,
                Description = "Any Description",
                Latitude = 18.473123M,
                Longitude = -69.809590M,
                Preacher = "Any Preacher",
                PhoneNumber = "809 - Any number",
                Sector = "Any sector"
            };
            Service.Add(church).ShouldBeTrue();
        }
        #endregion
        [Test]
        public void GetChurchesByBoundingBoxShouldReturnTheChurchesInsideTheBox()
        {
            Service.GetInBox(17.78934445183137, 19.29959436933543, -71.22706064453126, -68.78534921875001).Any().ShouldBeTrue();
        }
    }
}
