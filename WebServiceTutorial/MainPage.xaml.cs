using System;
using Xamarin.Forms;

namespace WebServiceTutorial
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            // On test que la variable que l'on a mise dans villeEntree n'est pas null ou un blanc
            if (!string.IsNullOrWhiteSpace(cityEntry.Text))
            {
                WeatherData weatherDataNeeded = await _restService.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherDataNeeded;
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={cityEntry.Text}";
            requestUri += "&units=metric"; // or units=imperial
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            Console.WriteLine("juste pour faire un test : " + requestUri + "\n");
            return requestUri;
        }
    }
}