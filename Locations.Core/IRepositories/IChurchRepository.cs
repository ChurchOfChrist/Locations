using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Locations.Core.Entities;

namespace Locations.Core.IRepositories
{
    public interface IChurchRepository : IRepository<Church>
    {
        IEnumerable<Church> GetInBox(DbGeography boundingBox);
    }
}