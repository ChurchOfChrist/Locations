using System.Data.Common;
using System.Data.Entity;
using Locations.Core.Entities;

namespace Locations.DataAccessLayer.Context
{
    public class ChurchDb : DbContext
    {
        public ChurchDb(): base("Database")
        {
            
        }

        public ChurchDb(DbConnection connection) : base(connection, true)
        {
            
        }
        #region DbSets 
        public DbSet<Country> Countries { get; set; }
        public DbSet<Church> Churches { get; set; }
        #endregion
    }
}
