using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseur.Models;
using ClientConvertisseur.Services.Interface;
using Microsoft.UI.Xaml.Controls;

namespace ClientConvertisseur.Services
{
    public class WSService : IService
    {


        #region Controleur
        private WSService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5176/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion
        #region Propriétés
        private static WSService _instance = null;
        private HttpClient _client;

        public HttpClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        #endregion
        #region Method
        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await _client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception ex)
            {
                return null;
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
        #endregion


    }
}
