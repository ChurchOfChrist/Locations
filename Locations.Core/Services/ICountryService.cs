using System.Collections.Generic;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public interface ICountryService
    {
        List<CountryViewModel> GetAll();
    }
}