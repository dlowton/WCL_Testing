using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;
using RestSharp.Authenticators;

namespace WCL_Testing
{
    class API_Engine
    {

        private string token;
        private RestClient core_client;

        public API_Engine(string id, string secret)
        {
            //Create the client and get the token.
            var client = new RestClient("https://www.warcraftlogs.com/oauth/token");
            client.Authenticator = new HttpBasicAuthenticator(id, secret);
            RestRequest r = new RestRequest(Method.POST);

            r.AddParameter("grant_type", "client_credentials");
            var response = client.Execute(r);
        }
    }
}
