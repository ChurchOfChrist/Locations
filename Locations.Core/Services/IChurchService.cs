using System.Collections.Generic;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public interface IChurchService
    {
        List<ChurchViewModel> GetByCountry(int countryId);
        List<ChurchViewModel> GetByCity(int cityId);
        List<ChurchViewModel> GetByCityAndSector(int cityId, string sectorName);
    }
}