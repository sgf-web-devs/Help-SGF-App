using System;
using HelpSGF.Models;

namespace HelpSGF.ViewModels
{
    public class LocationDetailViewModel : BaseViewModel
    {
        public LocationDetailViewModel()
        {

        }

        private Location _location;
        public Location Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public string MapURL
        {
            get
            {
                if(Location == null)
                {
                    return "";
                }

                return "https://api.mapbox.com/styles/v1/mapbox/streets-v10.html?title=false&zoomwheel=false&access_token=pk.eyJ1IjoiaGVscHNnZiIsImEiOiJjamt4ajMwZzAwOTdqM3VwZzI2MmxlMXV3In0.iukoLZaCrGXrOvJ8VlNDaA#16/" + Location.Latitude + "/" + Location.Longitude;
            }
        }
    }
}
