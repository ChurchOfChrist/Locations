using System.Data.Entity.Spatial;
using Locations.Core.Enumerations;

namespace Locations.Core.Helpers
{
    public static class GeoHelper
    {
        public static DbGeography FromLatLng(double lat, double lng, DbGeographySrid srid = DbGeographySrid.SridGps)
        {
            return DbGeography.PointFromText(string.Format("POINT({0},{1})", lng, lat), (int)srid);
        }

        public static DbGeography GetBox(double firstLongitude, double firstLatitude, double secondLongitude, double secondLatitude, DbGeographySrid srid = DbGeographySrid.SridGps)
        {
           return DbGeography.FromText(
             string.Format("POLYGON(({0} {1}, {3} {1}, {3} {2}, {0} {2}, {0} {1}))",
             firstLongitude,
             firstLatitude,
             secondLongitude,
             secondLatitude), (int)srid);
        }
    }
}
