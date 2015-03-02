using System.Linq;
using Locations.Core.Entities;
using Locations.Core.Helpers;
using Locations.Core.Services;
using Locations.Core.ViewModels;
using Locations.DataAccessLayer.Repositories;
using NUnit.Framework;
using Should;

namespace Locations.Core.Tests.Services
{
    [TestFixture]
    public class ChurchServiceTests
    {
        private readonly Manager _manager;
        private ChurchService Service { get; set; }
        public ChurchServiceTests()
        {
            _manager = new Manager();
        }
        [SetUp]
        public void Setups()
        {
            var repo = new ChurchRepository(_manager.Db);
            Service = new ChurchService(repo);
        }
        [Test]
        public void GetChurchesByBoundingBoxShouldReturnTheChurchesInsideTheBox()
        {
            var church = new ChurchViewModel
            {
                Latitude = 18.473123,
                Longitude = -69.809590,
                Preacher = "Any Preacher",
            };
            Service.Add(church).ShouldBeFalse();
            Service.GetInBox(17.789344, 19.299594, -71.227060, -68.785349).Any().ShouldBeTrue();
        }


    }
}
