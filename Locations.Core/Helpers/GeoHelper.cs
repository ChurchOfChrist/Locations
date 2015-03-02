using System.Data.Entity.Spatial;

namespace Locations.Core.Helpers
{
    public static class GeoHelper
    {
        public static DbGeography FromLatLng(double lat, double lng)
        {
            return DbGeography.PointFromText(string.Format("POINT({0} {1})", lat, lng), DbGeography.DefaultCoordinateSystemId);
        }

        public static DbGeography GetBox(double firstLongitude, double firstLatitude, double secondLongitude, double secondLatitude)
        {
           return DbGeography.FromText(
             string.Format("POLYGON(({0} {1}, {3} {1}, {3} {2}, {0} {2}, {0} {1}))",
             firstLongitude,
             firstLatitude,
             secondLongitude,
             secondLatitude), 
             DbGeography.DefaultCoordinateSystemId);
        }
    }
}
