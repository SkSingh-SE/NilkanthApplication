using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace BCAPIConnectivity.Classes
{
    public class APIClient
    {
        private static readonly SemaphoreSlim AccessTokenSemaphore;
        private static AccessToken _accessToken;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _scope;
        private readonly string _grantType;
        private readonly string _tenantId;
        private readonly string _tokenURL;
        private readonly string _environment;
        private readonly string _baseURL;
        static APIClient()
        {

            AccessTokenSemaphore = new SemaphoreSlim(1, 1);
        }

        public APIClient()
        {
            _clientId = System.Configuration.ConfigurationManager.AppSettings["ClientID"];
            //_clientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"];
            //_scope = System.Configuration.ConfigurationManager.AppSettings["Scope"];
            _grantType = System.Configuration.ConfigurationManager.AppSettings["GrantType"];
            //_tenantId = System.Configuration.ConfigurationManager.AppSettings["TenantID"];
            //_tokenURL = System.Configuration.ConfigurationManager.AppSettings["TokenURL"];
            _environment = System.Configuration.ConfigurationManager.AppSettings["Environment"];
            _baseURL = System.Configuration.ConfigurationManager.AppSettings["BaseURL"];
        }

        public async Task<AccessToken> GetAccessToken()
        {
            if (_accessToken != null && !_accessToken.Expired)
            {
                return _accessToken;
            }

            _accessToken = await FetchToken();
            return _accessToken;
        }

        private async Task<AccessToken> FetchToken()
        {
            try
            {
                await AccessTokenSemaphore.WaitAsync();

                if (_accessToken != null && !_accessToken.Expired)
                {
                    return _accessToken;
                }

                HttpClient httpClientToken = new HttpClient();

                Uri baseuri = new Uri(_tokenURL.Replace("{TenantID}", _tenantId));

                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("client_id", _clientId));
                values.Add(new KeyValuePair<string, string>("client_secret", _clientSecret));
                values.Add(new KeyValuePair<string, string>("scope", _scope));
                values.Add(new KeyValuePair<string, string>("grant_type", _grantType));

                var request = new HttpRequestMessage(HttpMethod.Post, baseuri + "/token")
                {
                    Content = new FormUrlEncodedContent(values)
                };

                HttpResponseMessage response = null;
                try
                {
                    response = httpClientToken.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
                }
                catch (Exception ex)
                {

                }
                AccessToken item = null;
                if (response.IsSuccessStatusCode)
                {
                    var JsonData = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        item = JsonConvert.DeserializeObject<AccessToken>(JsonData);
                    }
                    catch (Exception ex1)
                    {

                    }
                }

                return item;

            }
            catch (Exception ex)
            {
                AccessToken item = null;
                return item;
            }
            finally
            {
                AccessTokenSemaphore.Release(1);
            }
        }

        public async Task<IList<U>> GetData<U>(string apiendpoint)
        {
            IList<U> items = new List<U>();
            var accessToken = await GetAccessToken();

            HttpClient _httpClient = new HttpClient();

            Uri baseuri = new Uri(_baseURL + "/" + _tenantId + "/" + _environment);


            var request = new HttpRequestMessage(HttpMethod.Get, baseuri + apiendpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);

            HttpResponseMessage response = null;
            try
            {
                response = _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            }
            catch (Exception ex)
            {

            }

            if (response.IsSuccessStatusCode)
            {
                var JsonData = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var outer = JsonConvert.DeserializeObject<OData<object[]>>(JsonData);
                    for (int i = 0; i < outer.value.Length; i++)
                    {
                        items.Add(JsonConvert.DeserializeObject<U>(outer.value[i].ToString()));
                    }
                }
                catch (Exception ex1)
                {
                }
            }

            return items;
        }
    }
}
