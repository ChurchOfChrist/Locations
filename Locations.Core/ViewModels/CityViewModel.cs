using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel(City entity)
        {
            Name = entity.Name;
            CountryId = entity.CountryId;
        }
        #region properties
        public string Name { get; set; }
        public int CountryId { get; set; }
        #endregion
    }
}