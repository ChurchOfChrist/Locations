namespace Locations.Core.ViewModels
{
    public class CoordinatesViewModel
    {
        public CoordinatesViewModel()
        {
            
        }

        public CoordinatesViewModel(double nelt, double nelng, double swlt, double swlng)
        {
            Nelt = nelt;
            Nelng = nelng;
            Swlt = swlt;
            Swlng = swlng;
        }
        public double Nelt { get; set; }
        public double Nelng { get; set; }
        public double Swlt { get; set; }
        public double Swlng { get; set; }
    }
}