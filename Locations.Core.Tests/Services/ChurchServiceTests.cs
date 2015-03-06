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
                Lat = 18.765913990627432,
                Lng = -69.6533203125,
                Preacher = "Any Preacher",
                Address = "Somewhere in Neyba"
            };
            Service.Add(church).ShouldBeTrue();
            Service.GetInBox(19.9708, -68.8540, 16.9492, -73.7374).Count().ShouldEqual(1);
        }


    }
}
