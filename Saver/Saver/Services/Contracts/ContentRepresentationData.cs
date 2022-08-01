using Newtonsoft.Json;
using Saver.Models;
using Saver.Services.Interfaces;

namespace Saver.Services.Contracts
{
    public class ContentRepresentationData : IRequest
    {
        [JsonProperty("content")]
        public Content[] Content { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }
    }
}
