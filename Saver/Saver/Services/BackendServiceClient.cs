using Newtonsoft.Json;
using Saver.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Saver.Services
{
    public class BackendServiceClient : IHttpServiceClient
    {
        private static BackendServiceClient Instance;

        private readonly HttpClient httpClient;
        private readonly string hostIp;

        private BackendServiceClient(string hostIp)
        {
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            this.hostIp = hostIp;
        }

        public static BackendServiceClient GetInstance(string hostIp = "localhost") 
        {
            if (Instance == null) 
            {
                Instance = new BackendServiceClient(hostIp);
            }

            return Instance;
        }

        public IResponse GetRequest(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> PostRequestAsync(string endpoint, IRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, encoding: Encoding.UTF8, "application/json");
            var url = "http://192.168.16.109:5000/SyncContent";

            var client = new HttpClient();
            var resp = await client.PostAsync(url, data);

            return resp;
        }
    }
}
