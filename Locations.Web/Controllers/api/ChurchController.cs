using System.Collections.Generic;
using System.Web.Http;
using Locations.Core.Services;
using Locations.Core.ViewModels;

namespace Locations.Web.Controllers.api
{
    public class ChurchController : ApiController
    {
        private IChurchService Service { get; set; }
        public ChurchController(IChurchService churchService)
        {
            Service = churchService;
        }

        public List<ChurchViewModel> Get()
        {
            return Service.GetAll();
        }
        /// <summary>
        /// This method allow to get all the locations inside a box
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        public List<ChurchViewModel> Get(CoordinatesViewModel coords)
        {
            return Service.GetInBox(coords);
        }
        /// <summary>
        /// Method for adding a church
        /// </summary>
        /// <param name="church"></param>
        /// <returns></returns>
        public IHttpActionResult Post(ChurchViewModel church)
        {
            if (ModelState.IsValid)
            {
                var result = Service.Add(church);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

    }
}
