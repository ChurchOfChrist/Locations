namespace Locations.Core.Entities
{
    public class Contact : Entity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ChurchId { get; set; }
        public virtual Church Church { get; set; }
    }
}