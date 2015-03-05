using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class ChurchViewModel
    {
        public ChurchViewModel(Church entity)
        {
            Preacher = entity.Preacher;
            WorshipDays = entity.WorshipDays;
            Address = entity.Address;
            Lng = entity.Lng;
            Lat = entity.Lat;
        }

        public ChurchViewModel()
        {
        }

        #region properties
        public string Preacher { get; set; }
        public string WorshipDays { get; set; }
        public string Address { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        #endregion
    }
}