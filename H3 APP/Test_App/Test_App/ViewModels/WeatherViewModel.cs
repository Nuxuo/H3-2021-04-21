using Xamarin.Forms;
using Xamarin.Essentials;

namespace H3_App.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private string _CityName;
        private WeatherData ContextWeatherData;

        RestService _restService;

        public Command CityWeather { get; }
        public Command GPSWeather { get; }

        public WeatherViewModel()
        {
            Title = "Weather";
            _restService = new RestService();
            CityWeather = new Command(OnGetWeatherButtonClicked);
            GPSWeather = new Command(GeoRequestUri);
        }

        public string CityName
        {
            get => _CityName;
            set => SetProperty(ref _CityName, value);
        }
        public WeatherData weatherdata
        {
            get => ContextWeatherData;
            set => SetProperty(ref ContextWeatherData, value);
        }

        private async void OnGetWeatherButtonClicked()
        {
            string requestUri = string.Empty;
            requestUri += $"?q={_CityName}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";

            weatherdata = await _restService.GetWeatherData(Constants.OpenWeatherMapEndpoint + requestUri);
            CityName = weatherdata.Title;
        }

        private async void GeoRequestUri()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                string requestUri = string.Empty;
                requestUri += $"?lat=" + location.Latitude + "&lon=" + location.Longitude + "";
                requestUri += "&units=metric";
                requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";

                weatherdata = await _restService.GetWeatherData(Constants.OpenWeatherMapEndpoint + requestUri);
                weatherdata.Coord.Lat = location.Latitude;
                weatherdata.Coord.Lon = location.Longitude;
                CityName = weatherdata.Title;
            }
        }
    }
}