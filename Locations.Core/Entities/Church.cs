using System.Data.Entity.Spatial;

namespace Locations.Core.Entities
{
    /// <summary>
    /// This represents the properties of a church
    /// For now these properties focus on getting the location 
    /// and the minimun info of the church
    /// </summary>
    public class Church : Entity
    {
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string Sector { get; set; }
        public string Preacher { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DbGeography Location { get; set; }
        
    }
}
