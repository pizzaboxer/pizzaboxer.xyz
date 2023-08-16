using System.Text.Json.Serialization;

namespace PersonalWebsite.Models.Data
{
    public class GoogleIpRange
    {
        [JsonPropertyName("ipv4Prefix")]
        public string? Ipv4Prefix { get; set; }

        [JsonPropertyName("ipv6Prefix")]
        public string? Ipv6Prefix { get; set; }

        [JsonPropertyName("service")]
        public string Service { get; set; } = null!;

        [JsonPropertyName("scope")]
        public string Scope { get; set; } = null!;
    }
}
