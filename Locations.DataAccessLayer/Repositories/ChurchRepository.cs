using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.IRepositories;

namespace Locations.DataAccessLayer.Repositories
{
    public class ChurchRepository : Repository<Church>, IChurchRepository
    {
        public ChurchRepository(DbContext context) : base(context) { }

        public IEnumerable<Church> GetInBox(double nelt, double nelng, double swlt, double swlng)
        {
            return All().Where(c =>
                c.Lat <= nelt &&
                c.Lat >= swlt &&
                c.Lng <= nelng &&
                c.Lng >= swlng
                );
        }
    }
}
