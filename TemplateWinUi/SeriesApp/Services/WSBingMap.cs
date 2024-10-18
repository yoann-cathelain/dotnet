using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SeriesApp.Models;
using WebAPI_TP3.Models.EntityFramework;

namespace SeriesApp.Services;
class WSBingMap
{
    #region Constructeur
    public WSBingMap(HttpClient client)
    {
        var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
        string uri = loader.GetString("Bing_Map_URL");
        _client = client;
        _client.BaseAddress = new Uri(uri);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    #endregion
    #region Propriétés
    private static WSBingMap _instance = null;
    private static string bingMapKey = "Ag7KBEIMrvvjF2Kpz9Ze9UaNNoj1jkizmw-_bxWFpRaLJEXzBGNW-IFl4aHj5jd1";
    private HttpClient _client;
    public HttpClient Client
    {
        get
        {
            return _client;
        }
        set
        {
            _client = value;
        }
    }
    #endregion
    #region Methode

    public async void GetCoordinates(Utilisateur utilisateur)
    {
        string uri = $"{utilisateur.CodePostal}/{utilisateur.Ville}/{utilisateur.Rue}?key={bingMapKey}";
        Rootobject.Root root =await 
            _client.GetFromJsonAsync<Rootobject.Root>(uri);

        var res = root.resourceSets.Select(r => r.resources).First().First().point;
        utilisateur.Latitude = (float?) res.coordinates[0];
        utilisateur.Longitude = (float?) res.coordinates[1];
    }

    public static WSBingMap GetInstance()
    {
        if (_instance == null)
        {
            _instance = new WSBingMap(new HttpClient());

        }
        return _instance;
    }
    #endregion


}
