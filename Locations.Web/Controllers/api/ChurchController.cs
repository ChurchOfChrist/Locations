using System.Collections.Generic;
using System.Web.Http;
using Locations.Core.Services;
using Locations.Core.ViewModels;

namespace Locations.Web.Controllers.api
{
    public class ChurchController : ApiController
    {
        private readonly IChurchService _service;
        public ChurchController(IChurchService churchService)
        {
            _service = churchService;
        }

        public List<ChurchViewModel> Get()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// This method allow to get all the locations inside a box
        /// </summary>
        /// <param name="nelt"></param>
        /// <param name="nelng"></param>
        /// <param name="swlt"></param>
        /// <param name="swlng"></param>
        /// <returns></returns>
        public List<ChurchViewModel> Get(double nelt, double nelng, double swlt, double swlng)
        {
            return _service.GetInBox(new CoordinatesViewModel(nelt,nelng,swlt,swlng));
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
                var result = _service.Add(church);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

    }
}
