using ExternalApiParserWorker.Infrastructure.Hosts.ResponseModels;

namespace ExternalApiParserWorker.Infrastructure.Hosts
{
    public interface IHost<Tresponse>
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string GetEndpoint { get; set; }

        public bool HasPaging { get; set; }

        public Task<List<Iitem>> GetItemsAsync();

        public IResponseModel NextPage(int page);

        public Tresponse ExpectedResponseModel { get; set; }
    }
}
