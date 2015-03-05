using System.Collections.Generic;
using System.Web.Mvc;
using Locations.Core.Services;
using Locations.Core.ViewModels;
using Locations.DataAccessLayer.Context;
using Locations.DataAccessLayer.Repositories;

namespace Locations.Web.Controllers
{
    public class HomeController : Controller
    {
        public IChurchService ChurchService { get; set; }
        public HomeController()
        {
            ChurchService = new ChurchService(new ChurchRepository(new LocationDb()));
        }
        public ActionResult Index()
        {
            return View();
        }
       
        public bool AddPoint(string address, double lat, double lng, string preacher, string days)
        {
            return ChurchService.Add(new ChurchViewModel
            {
                Address = address,
                Latitude = lat,
                Longitude = lng,
                Preacher = preacher,
                WorshipDays = days,
            });
        }
        public ActionResult PointsInTheBox(double nelt, double nelng, double swlt, double swlng)
        {
            return Json(ChurchService.GetInBox(nelt, nelng, swlt, swlng), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            return Json(ChurchService.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}