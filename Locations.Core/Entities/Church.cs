using System.Collections.Generic;

namespace Locations.Core.Entities
{
    /// <summary>
    /// This represents the properties of a church
    /// For now these properties focus on getting the location 
    /// and the minimun info of the church
    /// </summary>
    public class Church : Entity
    {
        public virtual List<WorshipDay> WorshipDays { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; }
        public virtual List<Contact> Contacts { get; set; }
    }
}
