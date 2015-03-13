using System.Collections.Generic;
using System.Linq;

namespace Locations.Core.Extensions
{
    public static class Helper
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }
    }
}