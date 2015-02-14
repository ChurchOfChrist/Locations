namespace Locations.Core.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}