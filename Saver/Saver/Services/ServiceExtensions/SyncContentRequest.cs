using Saver.Services.Contracts;
using Saver.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace Saver.Services.ServiceExtensions
{
    public static class SyncContentRequest
    {
        public static async Task<HttpStatusCode> SyncAllContent(this IHttpServiceClient serviceClient, ContentRepresentationData requestData) 
        {
            var result = await serviceClient.PostRequestAsync("SyncContent", requestData);

            return result.StatusCode;
        }
    }
}
