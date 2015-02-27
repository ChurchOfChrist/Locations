using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using Locations.Core.Entities;
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

        public List<ChurchViewModel> GetByCountry(int countryId)
        {
            return _repository.GetByCountry(countryId).Select(c => new ChurchViewModel(c)).ToList();
        }

        public List<ChurchViewModel> GetByCity(int cityId)
        {
            return _repository.GetByCity(cityId).Select(c => new ChurchViewModel(c)).ToList();
        }

        public List<ChurchViewModel> GetByCityAndSector(int cityId, string sectorName)
        {
            return _repository.GetByCityAndSector(cityId, sectorName).Select(c => new ChurchViewModel(c)).ToList();
        }

        public bool Add(ChurchViewModel church)
        {
            if (String.IsNullOrEmpty(church.Sector) || 
                church.CityId ==0 || String.IsNullOrEmpty(church.Preacher) 
                || String.IsNullOrEmpty(church.PhoneNumber))
            {
                return false;
            }

            _repository.Add(new Church
            {
                CityId = church.CityId,
                Description = church.Description,
                Latitude = church.Latitude,
                Longitude = church.Longitude,
                Preacher = church.Preacher,
                PhoneNumber = church.PhoneNumber,
                Sector = church.Sector
            });
            _repository.SaveChanges();
            return true;
        }

        public List<ChurchViewModel> GetInBox(double firstLongitude, double firstLatitude, double secondLongitude, double secondLatitude)
        {
            var boundingBox = Helpers.GeoHelper.GetBox(firstLongitude, firstLatitude, secondLongitude, secondLatitude);
           return _repository.GetInBox(boundingBox).Select(c => new ChurchViewModel(c)).ToList();
        }
    }
}