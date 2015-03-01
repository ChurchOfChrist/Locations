using System.Collections.Generic;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public interface IChurchService
    {
        bool Add(ChurchViewModel church);
        List<ChurchViewModel> GetInBox(double firstLongitude, double firstLatitude, double secondLongitude, double secondLatitude);
    }
}