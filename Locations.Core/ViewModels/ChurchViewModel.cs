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
            Longitude = entity.Lng;
            Latitude = entity.Lat;
            Comment = entity.Comment;
            Id = entity.Id;
        }

        
        public ChurchViewModel()
        {
        }

        #region properties
        public int Id { get; set; }
        public List<WorshipDayViewModel> WorshipDays { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public List<ContactViewModel> Contacts { get; set; }
        public string Comment { get; set; }
        #endregion
    }
}