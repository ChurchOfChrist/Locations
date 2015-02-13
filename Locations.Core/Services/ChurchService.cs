using System.Collections.Generic;
using System.Linq;
using Locations.Core.IRepositories;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public class ChurchService : IChurchService
    {
        private readonly IChurchRepository _repository;

        public ChurchService(IChurchRepository repository)
        {
            _repository = repository;
        }

        public List<ChurchViewModel> GetByCountry(int countryId)
        {
            return _repository.GetByCountry(countryId).Select(c => new ChurchViewModel(c)).ToList();
        }

        public List<ChurchViewModel> GetByCity(int cityId)
        {
            return _repository.GetByCity(cityId).Select(c => new ChurchViewModel(c)).ToList();
        }

        public List<ChurchViewModel> GetByCityAndSector(int cityId, string sectorName)
        {
            return _repository.GetByCityAndSector(cityId, sectorName).Select(c => new ChurchViewModel(c)).ToList();
        }
    }
}