using System;
using Xamarin.Forms;

namespace WebServiceTutorial
{
    public partial class MainPage : ContentPage
    {
        //A ContentPage is a visual element 
        //that displays a single view and occupies most of the screen.
        RestService _restService;

        public MainPage()
        {
            //Initialisation de la clase ContentPage
            //widely observable as part of the infrastructure provided by frameworks 
            //or technologies that use XAML combined with application
            InitializeComponent();
            _restService = new RestService();
        }

        // gestion des événements avec la classe EventArgs
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
            requestUri += "&units=metric"; // ou units=imperial
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            //Console.WriteLine("juste pour faire un test : " + requestUri + "\n");
            return requestUri;
        }
    }
}