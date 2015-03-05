using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.DataAccessLayer.Repositories
{
    public class ChurchRepository : Repository<Church>, IChurchRepository
    {
        public ChurchRepository(DbContext context) : base(context) { }
       
        public IEnumerable<Church> GetInBox(DbGeography boundingBox)
        {
            return All().Where(c => c.Location.Intersects(boundingBox));
        }
    }
}
