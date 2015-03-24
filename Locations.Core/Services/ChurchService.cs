using System.Collections.Generic;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.Extensions;
using Locations.Core.IRepositories;
using Locations.Core.ViewModels;

namespace Locations.Core.Services
{
    public class ChurchService : IChurchService
    {
        private readonly IChurchRepository _repository;

        public ChurchService(IChurchRepository repository)
        {
            _repository = repository;
        }
        public bool Add(ChurchViewModel church)
        {
            if (church.Contacts.IsNullOrEmpty() || church.WorshipDays.IsNullOrEmpty())
                return false;

            var toadd = new Church
            {
                Lat = church.Latitude,
                Lng = church.Longitude,
                Contacts = church.Contacts.Select(c => c.ToEntity()).ToList(),
                WorshipDays = church.WorshipDays.Select(w => w.ToEntity()).ToList(),
                Comment = church.Comment
            };
            _repository.Add(toadd);
            _repository.SaveChanges();
            return true;
        }

        public List<ChurchViewModel> GetInBox(CoordinatesViewModel coords)
        {
            return _repository.GetInBox(coords.Nelt, coords.Nelng, coords.Swlt, coords.Swlng).Select(c => new ChurchViewModel(c)).ToList();
        }

        public List<ChurchViewModel> GetAll()
        {
            return _repository.All().ToList().Select(c => new ChurchViewModel(c)).ToList();
        }
    }
}