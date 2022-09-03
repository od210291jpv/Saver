using ExternalApiParserWorker.Infrastructure.Hosts.ResponseModels;

namespace ExternalApiParserWorker.Infrastructure.Builders
{
    public class HostBuilder<TResponseType> where TResponseType : IResponseModel
    {
        private BaseContentHost<TResponseType> contentHost;
        private HttpClient httpClient;

        public HostBuilder(TResponseType type)
        {
            this.httpClient = new HttpClient();
            this.contentHost = new BaseContentHost<TResponseType>(httpClient, type);
        }

        public HostBuilder<TResponseType> WithName(string name) 
        {
            this.contentHost.Name = name;
            return this;
        }

        public HostBuilder<TResponseType> WithUrl(string url) 
        {
            this.contentHost.Url = url;
            return this;
        }

        public HostBuilder<TResponseType> WithGetEndpoint(string getEndpoint) 
        {
            this.contentHost.GetEndpoint = getEndpoint;
            return this;
        }

        public HostBuilder<TResponseType> WithWasPaging(bool hasPaging) 
        {
            this.contentHost.HasPaging = hasPaging;
            return this;
        }

        public BaseContentHost<TResponseType> Build() 
        {
            return this.contentHost;
        }
    }
}
