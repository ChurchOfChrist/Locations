using System.Collections.Generic;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public interface IChurchService
    {
        bool Add(ChurchViewModel church);
        List<ChurchViewModel> GetInBox(double nelt, double nelng, double swlt, double swlng);
        List<ChurchViewModel> GetAll();
    }
}