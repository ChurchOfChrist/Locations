using System.Data.Entity.Spatial;
using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class ChurchViewModel
    {
        public ChurchViewModel(Church entity)
        {
            Preacher = entity.Preacher;
            Location = entity.Location;
            WorshipDays = entity.WorshipDays;
            Address = entity.Address;
        }


        public ChurchViewModel()
        {
        }

        #region properties
        public string Preacher { get; set; }
        public string WorshipDays { get; set; }
        public DbGeography Location { get; set; }
        public string Address { get; set; }
        #endregion
    }
}