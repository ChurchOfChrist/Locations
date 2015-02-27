namespace Locations.Core.Enumerations
{
    /// <summary>
    /// A Spatial Reference System Identifier (SRID) is a unique value used to unambiguously identify projected, unprojected, 
    /// and local spatial coordinate system definitions. These coordinate systems form the heart of all GIS applications.
    /// iEPSG SRID 4326 for the Earth (including LatLngs you get from Google Maps).
    /// EPSG SRID 3857 for a flat 2D map (like a Google Custom Map).
    /// </summary>
    public enum DbGeographySrid
    {
        SridGps = 4326,
        Srid2DPlane = 3857,
    }
}