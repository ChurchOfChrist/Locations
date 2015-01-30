namespace Locations.Core.Entities
{
    /// <summary>
    /// Representation of a country
    /// </summary>
    public class Country : Entity
    {
        public string Name { get; set; }
        public int CallingCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Language { get; set; }
    }
}
