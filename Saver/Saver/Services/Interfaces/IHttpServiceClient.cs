using System.Net.Http;
using System.Threading.Tasks;

namespace Saver.Services.Interfaces
{
    public interface IHttpServiceClient
    {
        IResponse GetRequest(string url);

        Task<HttpResponseMessage> PostRequestAsync(string endpoint, IRequest request);
    }
}
