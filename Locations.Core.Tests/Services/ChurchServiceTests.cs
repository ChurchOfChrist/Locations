using System.Linq;
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
                Lat = 18.473123,
                Lng = -69.809590,
                Preacher = "Any Preacher",
            };
            Service.Add(church).ShouldBeFalse();
            Service.GetInBox(19.299594, 17.789344, -68.785349, -71.227060).Any().ShouldBeTrue();
        }


    }
}
