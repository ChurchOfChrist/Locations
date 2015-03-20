using System;
using System.Collections.Generic;
using Locations.Core.ViewModels;

namespace Locations.DataAccessLayer.Context
{
    public static class EntitySeed
    {
        public static readonly List<ContactViewModel> DefaultContacts = new List<ContactViewModel>
        {
            new ContactViewModel() {FullName = "AnyContact 1", PhoneNumber = "Any809Number", Email = "Any@email.com"},
            new ContactViewModel() {FullName = "AnyContact 2", PhoneNumber = "Any829Number", Email = "Any@mail.com"},
        };

        public static readonly List<WorshipDayViewModel> DefaultWorshipDays = new List<WorshipDayViewModel>
        {
            new WorshipDayViewModel() { Day= DayOfWeek.Sunday, Start = new DateTime(2015,01,11,9,0,0), End = new DateTime(2015,01,11,11,0,0), Description = "Culto Principal Primer Servicio"},
            new WorshipDayViewModel() { Day= DayOfWeek.Sunday, Start = new DateTime(2015,01,11,17,0,0), End = new DateTime(2015,01,11,19,0,0), Description = "Culto Principal Segundo Servicio"},

        };
    }
}
