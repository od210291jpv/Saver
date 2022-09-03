using Newtonsoft.Json;

namespace ExternalApiParserWorker.Infrastructure.Hosts.ResponseModels
{
    public class BaseContentHost<Tresponse> : IHost<Tresponse> where Tresponse : IResponseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string GetEndpoint { get; set ; }
        public bool HasPaging { get; set; }
        private int CurrentPage { get; set; }
        public Tresponse ExpectedResponseModel { get; set; }

        private HttpClient httpClient;

        public BaseContentHost(HttpClient client, Tresponse responseType)
        {
            this.httpClient = client;
            this.ExpectedResponseModel = responseType;
        }

        public async Task<List<Iitem>> GetItemsAsync()
        {
            var response = await this.httpClient.GetAsync(GetEndpoint);

            return JsonConvert.DeserializeObject<Tresponse>(await response.Content.ReadAsStringAsync()).items;

        }

        public IResponseModel NextPage(int page)
        {
            throw new NotImplementedException();
        }
    }
}
