using System.Collections.Generic;
using System.Linq;
using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class ChurchViewModel
    {
        public ChurchViewModel(Church entity)
        {
            Contacts = entity.Contacts.Select(c => new ContactViewModel(c)).ToList();
            WorshipDays = entity.WorshipDays.Select(w => new WorshipDayViewModel(w)).ToList();
            Address = entity.Address;
            Lng = entity.Lng;
            Lat = entity.Lat;
        }

        public ChurchViewModel()
        {
        }

        #region properties
        public string Preacher { get; set; }
        public List<WorshipDayViewModel> WorshipDays { get; set; }
        public string Address { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public List<ContactViewModel> Contacts { get; set; }

        #endregion
    }
}