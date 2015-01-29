namespace Locations.Core.Entities
{
    public class Church : Entity
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string Sector { get; set; }
        public string Preacher { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
       
    }
}
