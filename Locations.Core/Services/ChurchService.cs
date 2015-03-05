using System;
using System.Collections.Generic;
using System.Linq;
using Locations.Core.Entities;
using Locations.Core.Helpers;
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
            if (String.IsNullOrEmpty(church.Preacher))
            {
                return false;
            }

            _repository.Add(new Church
            {
                Preacher = church.Preacher,
                Location = GeoHelper.FromLatLng(church.Latitude, church.Longitude),
                Address = church.Address,
            });
            _repository.SaveChanges();
            return true;
        }

        public List<ChurchViewModel> GetInBox(double nelt, double nelng, double swlt, double swlng)
        {
            var boundingBox = GeoHelper.GetBox(nelt, nelng, swlt, swlng);
            var klk = _repository.GetInBox(boundingBox);
            return klk.Select(c => new ChurchViewModel(c)).ToList();
        }

        public List<ChurchViewModel> GetAll()
        {
            return _repository.All().Select(c => new ChurchViewModel(c)).ToList();
        }
    }
}