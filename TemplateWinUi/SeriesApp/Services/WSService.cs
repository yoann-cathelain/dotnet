using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SeriesApp.Contracts.Services;
using WebAPI_TP3.Models.EntityFramework;
using Windows.Media.Protection.PlayReady;

namespace SeriesApp.Services
{
    class WSService : IWSService
    {

        #region Controleur

        public WSService(HttpClient client)
        {
            _client = client;
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            string uri = loader.GetString("ROOT_WebAPI_URL");
            _client.BaseAddress = new Uri(uri);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        #region Propriétés
        private static WSService _instance = null;
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

        public async Task<Utilisateur> GetUserByEmailAsync(string email)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            string uri = loader.GetString("GET_User_Mail_URL");
            string completeUri = String.Concat(uri, email);
            try
            {
                return await _client.GetFromJsonAsync<Utilisateur>(completeUri);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task PutUtilisateur(int id, Utilisateur utilisateur)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            string uri = loader.GetString("ROOT_User_URL");
            string completeUri = String.Concat(uri, id);
            try
            {
                await _client.PutAsJsonAsync(completeUri, utilisateur);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task PostUtilisateur(Utilisateur utilisateur)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            string uri = loader.GetString("ROOT_User_URL");
            try
            {
                await _client.PostAsJsonAsync(uri, utilisateur);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public static WSService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WSService(new HttpClient());

            }
            return _instance;
        }
    }
}
