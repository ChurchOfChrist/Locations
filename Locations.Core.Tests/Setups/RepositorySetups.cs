using Locations.Core.Entities;
using Locations.Core.IRepositories;
using NSubstitute;

namespace Locations.Core.Tests.Setups
{
    public static class RepositorySetups
    {
        public static void With<T>(this IRepository<T> repository, params T[] entity) where T : Entity
        {
            repository.All().Returns(entity);
        }
    }
}