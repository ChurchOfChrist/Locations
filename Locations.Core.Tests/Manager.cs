using Locations.DataAccessLayer.Context;

namespace Locations.Core.Tests
{
    public class Manager
    {
        public LocationDb Db;

        public Manager()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            Db = new LocationDb(connection);
        }
    }
}