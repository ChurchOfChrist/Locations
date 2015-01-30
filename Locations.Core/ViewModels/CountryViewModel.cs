using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class CountryViewModel
    {
        public CountryViewModel(Country entity)
        {
            Name = entity.Name;
            CallingCode = entity.CallingCode;
            Latitude = entity.Latitude;
            Longitude = entity.Longitude;
            Language = entity.Language;
        }

        #region properties
        public string Name { get; set; }
        public int CallingCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Language { get; set; }
        #endregion
    }
}