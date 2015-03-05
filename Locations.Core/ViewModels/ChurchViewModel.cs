using System.Data.Entity.Spatial;
using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class ChurchViewModel
    {
        public ChurchViewModel(Church entity)
        {
            Preacher = entity.Preacher;
            Latitude = entity.Location.Latitude ?? 0;
            Longitude = entity.Location.Longitude ?? 0;
            WorshipDays = entity.WorshipDays;
            Address = entity.Address;
        }

        public ChurchViewModel()
        {
        }

        #region properties
        public string Preacher { get; set; }
        public string WorshipDays { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        #endregion
    }
}