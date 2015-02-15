using Locations.Web.Controllers;
using NUnit.Framework;
using Should;

namespace Locations.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexShouldReturnAnViewResult()
        {
            var homeController = new HomeController();
            var result = homeController.Index();
            result.ShouldNotBeNull();
        }

    }
}
