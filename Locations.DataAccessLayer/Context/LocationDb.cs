using System.Data.Common;
using System.Data.Entity;
using Locations.Core.Entities;

namespace Locations.DataAccessLayer.Context
{
    public class LocationDb : DbContext
    {
        public LocationDb(): base("Database")
        {
            
        }

        public LocationDb(DbConnection connection) : base(connection, contextOwnsConnection: true)
        {
            
        }

        #region DbSets 
        public DbSet<Church> Churches { get; set; }
        #endregion
    }
}
