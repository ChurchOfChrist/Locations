using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class ChurchViewModel
    {
        public ChurchViewModel(Church entity)
        {
            CityId = entity.CityId;
            Sector = entity.Sector;
            Preacher = entity.Preacher;
            PhoneNumber = entity.PhoneNumber;
            Description = entity.Description;
            Latitude = entity.Latitude;
            Longitude = entity.Longitude;
            City = entity.City;

        }

        public ChurchViewModel()
        {
        }

        #region properties
        public int CityId { get; set; }
        public City City { get; set; }
        public string Sector { get; set; }
        public string Preacher { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        #endregion
    }
}