using System.Collections.Generic;
using System.Linq;
using Locations.Core.IRepositories;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;

        public CountryService(ICountryRepository repository)
        {
            _repository = repository;
        }
        public List<CountryViewModel> GetAll()
        {
            return _repository.All().Select(c => new CountryViewModel(c)).ToList();
        }
    }
}