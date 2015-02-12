using System.Collections.Generic;
using System.Linq;
using Locations.Core.IRepositories;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public class CityService 
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public List<CityViewModel> GetByCountry(int countryId)
        {
            return _repository.GetByCountry(countryId).ToList().Select(c => new CityViewModel(c)).ToList();
        }
    }
}