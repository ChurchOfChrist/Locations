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
        //TODO: Convert this to preachers with phone number
        public string Preacher { get; set; }
        //TODO: Convert this into a entity with Day and time span
        public string WorshipDays { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; }
        
    }
}
