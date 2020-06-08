# WebServiceTutorial
Merci à Microsoft pour la documentation sur les API REST et C# .NET Xamarin

Dans ce fichier, j'explique mon cheminement

Dans ce projet, il y a un fichier MainPage.xaml et MainPage.xaml.cs

Dans le premier, cela ressemble beaucoup au fichier .xml généré par Qt Designer sous Qt Creator

Dans ce fichier .xaml, on fait la construction des parties de l'application au niveau interface graphique Front End

On installe le bouton d'activation principal pour demander les informations sur le temps.

Un système (identique au signal & slots) permet d'activer l'appel aux données de l'API de manière asynchrone grâce 
à la fonction appelée de manière asynchrone gérant les événements :
async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }
       
 On est ici dans le cadre de la programmation événementielle , exactement comme avec Qt/C++
 
 
