using System.Collections.Generic;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public interface ICityService
    {
        List<CityViewModel> GetByCountry(int countryId);
    }
}