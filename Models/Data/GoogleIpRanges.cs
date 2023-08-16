using System.Text.Json.Serialization;

namespace PersonalWebsite.Models.Data
{
    public class GoogleIpRanges
    {
        [JsonPropertyName("syncToken")]
        public string SyncToken { get; set; } = null!;

        [JsonPropertyName("creationTime")]
        public string CreationTime { get; set; } = null!;

        [JsonPropertyName("prefixes")]
        public IEnumerable<GoogleIpRange> Prefixes { get; set; } = null!;
    }
}
