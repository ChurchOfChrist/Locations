using Effort;
using Locations.DataAccessLayer.Context;

namespace Locations.Core.Tests
{
    public class Manager
    {
        public readonly LocationDb Db;

        public Manager()
        {
            var connection = DbConnectionFactory.CreateTransient();
            Db = new LocationDb(connection);
        }
    }
}