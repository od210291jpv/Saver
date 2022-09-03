using ExternalApiParserWorker.Infrastructure.Hosts;
using ExternalApiParserWorker.Infrastructure.Hosts.ResponseModels;

namespace ExternalApiParserWorker.Services.ExternalApiParser
{
    public class HostsParser
    {
        private List<BaseContentHost<IResponseModel>> hosts;

        public HostsParser()
        {
            this.hosts = new List<BaseContentHost<IResponseModel>>();
        }

        public void AddHost(BaseContentHost<IResponseModel> host) 
        {
            hosts.Add(host);
        }

        public async Task<List<Iitem>> ParseHostByNameAsync(string name) 
        {
            var hst = this.hosts.Where(h => h.Name == name).ToArray();

            if (hst.Length > 0) 
            {
                var neededHost = hst.First();

                List<Iitem> results = await neededHost.GetItemsAsync();

                return results;
            }

            return new List<Iitem>();
        }
    }
}
