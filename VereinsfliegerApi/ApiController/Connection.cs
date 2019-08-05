using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsflieger.Api
{
    public class Connection
    {
        /// <summary>
        /// initialisiert einen neuen Controller für den Zugriff auf Vereinsflieger
        /// </summary>
        /// <param name="AppKey">AppKey, welcher von Vereinsflieger.de bereitgestellt wird.</param>
        public Connection(string AppKey)
        {
            _appKey = AppKey;
        }

        public string Accesstoken { get; private set; }
        public bool Loggedin { get; private set; }
        public static readonly string restBaseUrl = "https://www.vereinsflieger.de/interface/rest/";

        private readonly string _appKey;

        public HttpClient GetNewClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Christians Cooles VereinsfliegerTool - Moin Zusammen");
            return client;
        }

        public Dictionary<string, string> GetDefaultParameter()
        {
            var parameters = new Dictionary<string, string>() {
                { "accesstoken", Accesstoken }
            };
            return parameters;
        }


        public async Task GetAccesstokenAsync()
        {
            if (string.IsNullOrEmpty(Accesstoken))
            {
                HttpResponseMessage response;

                using (var client = GetNewClient())
                    response = await client.GetAsync(restBaseUrl + "auth/accesstoken");

                if (response.IsSuccessStatusCode)
                {
                    dynamic jsonAnswer = Newtonsoft.Json.JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    Accesstoken = jsonAnswer.accesstoken;
                }
                else throw new Exception(response.ToString());

                response.Dispose();
            }
        }

        /// <summary>
        /// Login bei Vereinsflieger in die REST-Schnittstelle. Bitte darauf achten da der User die entsprechenden Berechtigungen hat.
        /// </summary>
        /// <param name="username">Benutzername bei vereinsflieger.de</param>
        /// <param name="password">Kennwort bei vereinsflieger.de</param>
        /// <returns></returns>
        public async Task LoginAsync(string username, string password)
        {
            await GetAccesstokenAsync();

            if (!Loggedin)
            {
                string hash;
                HttpResponseMessage response;

                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, password);
                }

                var parameters = GetDefaultParameter();
                parameters.Add("appkey", _appKey);
                parameters.Add("username", username);
                parameters.Add("password", hash);

                using (var client = GetNewClient())
                {
                    response = await client.PostAsync(restBaseUrl + "auth/signin", new FormUrlEncodedContent(parameters));
                }

                if (response.IsSuccessStatusCode)
                    Loggedin = true;
                else
                    throw new UnauthorizedAccessException($"Benutzername und/oder passwort falsch/n{response.ToString()}");

                response.Dispose();
            }
        }

        /// <summary>
        /// Hilfsklasse für die erzeugung des MD5 Hashes, welcher von Vereinsflieger benötigt wird
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
