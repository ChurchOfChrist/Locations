using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
                Location = GeoHelper.FromLatLng(church.Latitude, church.Longitude)
            });
            _repository.SaveChanges();
            return true;
        }

        public List<ChurchViewModel> GetInBox(double firstLongitude, double firstLatitude, double secondLongitude, double secondLatitude)
        {
            var boundingBox = GeoHelper.GetBox(firstLongitude, firstLatitude, secondLongitude, secondLatitude);
            var klk = _repository.GetInBox(boundingBox);
            return klk.Select(c => new ChurchViewModel(c)).ToList();
        }
    }
}