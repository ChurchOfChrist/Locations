using System.Data.Entity.Spatial;

namespace Locations.Core.Helpers
{
    public static class GeoHelper
    {
        public static DbGeography FromLatLng(double lat, double lng)
        {
            return DbGeography.PointFromText(string.Format("POINT({0} {1})", lat, lng), DbGeography.DefaultCoordinateSystemId);
        }
        public static DbGeography GetBox(double nelt, double nelng, double swlt, double swlng)
        {
            return DbGeography.FromText(
                string.Format("POLYGON(({0} {1}, {2} {1}, {2} {3}, {0} {3}, {0} {1}))",
                    nelt, nelng, swlt, swlng));
        }
    }
}
