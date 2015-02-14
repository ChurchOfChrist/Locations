using Locations.DataAccessLayer.Context;

namespace Locations.DataAccessLayer.Tests.Setups
{
    public static class ContextSetups
    {
        public static void DefaultCountries(this ChurchDb context)
        {
            context.Countries.AddRange(EntitySeed.DefaultCountries);
            context.SaveChanges();
        }

        public static void DefaultCities(this ChurchDb context)
        {
            context.Cities.AddRange(EntitySeed.DefaultCities);
            context.SaveChanges(); 
        }

        public static void DefaultChurches(this ChurchDb context)
        {
            context.Churches.AddRange(EntitySeed.DefaultChurches);
            context.SaveChanges();
        }
    }
}