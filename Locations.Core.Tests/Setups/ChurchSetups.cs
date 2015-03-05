using Locations.Core.IRepositories;
using Locations.DataAccessLayer.Context;

namespace Locations.Core.Tests.Setups
{
    public static class ChurchSetups
    {
        public static void DefaultList(this IChurchRepository repo)
        {
            repo.With(EntitySeed.DefaultChurches);
        }



    }
}