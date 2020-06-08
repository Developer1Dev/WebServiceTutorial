# WebServiceTutorial
Merci à Microsoft pour la documentation sur le langage C# .NET Xamarin

Dans ce fichier, j'explique mon cheminement pour l'application de demande des données à l'API de météo :
https://openweathermap.org/api

J'ai également ajouté une image.

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
 
 System.Net.Http.HttpClient fournit une classe de base pour envoyer des requêtes HTTP et recevoir des réponses HTTP d'une ressource idenitifiée par une URI (  https://dev.to/flippedcoding/what-is-the-difference-between-a-uri-and-a-url-4455#:~:text=For%20starters%2C%20URI%20stands%20for,are%20a%20subset%20of%20URIs. )
 
response.Content.ReadAsStringAsync  : gets or sets la réponse d'un message HTTP ( C'est l'analogue de JSON.stringify

On installe Newtonsoft Library pour utiliser JSON Converter, qui est un framework JSON haute-performance.
https://www.c-sharpcorner.com/article/working-with-json-string-in-C-Sharp/

JsonConvert

En C#, un System.String est un JSON !
https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonConvert_DeserializeObject.htm

BindingContext est un attribut d'un BindableObject

Dans MainPage.xaml, quand je clique sur "Binding", clque droit, "afficher le code", cela me renvoie directement vers
le code de MainPage.xaml.cs

Cette variable, permet de faire le lien entre les données récupérés en réponse HTTP , et stockées dans BindingContext et ce sera donc affichée sur l'interface Front (mobile phone)

D'où l'utilisation du Mot-clé "Bind" dans le fichier MainPage.xaml à chaque fois que l'on a besoin d'une donnée issue de l'appel à l'API , donnée rangée dans weatherData et mise en lien avec BindingContext

https://www.telerik.com/blogs/using-xaml-xamarin-forms-part-3-accessing-dynamic-data

namespace Xamarin.Forms
{
    //
    // Résumé :
    //     Xamarin.Forms.Page qui affiche une vue unique.
    [ContentProperty("Content")]
    public class ContentPage : TemplatedPage
    {
        //
        // Résumé :
        //     Magasin de stockage de la propriété Xamarin.Forms.ContentPage.Content.
        public static readonly BindableProperty ContentProperty;

        public ContentPage();

        //
        // Résumé :
        //     Obtient ou définit la vue qui comprend le contenu de la page.
        //
        // Valeur :
        //     Une Xamarin.Forms.View sous-classe, nullou.
        public View Content { get; set; }

        //
        // Résumé :
        //     Méthode qui est appelée lorsque le contexte de liaison change.
        protected override void OnBindingContextChanged();
    }
}

