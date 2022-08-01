using Newtonsoft.Json;

namespace SaverBackend.DTO
{
    public class CategoryDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }
    }
}
