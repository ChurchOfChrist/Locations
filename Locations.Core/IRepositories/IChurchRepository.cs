using System.Collections.Generic;
using Locations.Core.Entities;

namespace Locations.Core.IRepositories
{
    public interface IChurchRepository : IRepository<Church>
    {
        IEnumerable<Church> GetInBox(double nelt, double nelng, double swlt, double swlng);
    }
}