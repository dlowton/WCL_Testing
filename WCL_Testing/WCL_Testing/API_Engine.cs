using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace WCL_Testing
{
    class API_Engine
    {

        private string token;
        private RestClient core_client;

        
        

        public API_Engine()
        {
            
        }

        public void Get_Token(string id, string secret)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //Create the client and get the token.
            var client = new RestClient("https://www.warcraftlogs.com/oauth/token");
            client.Authenticator = new HttpBasicAuthenticator(id, secret);
            
            RestRequest r = new RestRequest(Method.POST);

            r.AddParameter("grant_type", "client_credentials");
            var response = client.Execute(r);

            //Get the content into JSON format.
            var j_resp = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            //Grab and print the access token.
            foreach (KeyValuePair<string, string> entry in j_resp)
            {
                Console.WriteLine(entry.Key + ": "+ entry.Value);
                if (entry.Key == "access_token")
                {
                    token = entry.Value;
                    Console.WriteLine("Auth successful, access token stored.");
                }
            }
        }
    }
}
