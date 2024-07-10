using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using PersonalWebsite.Models.Data;
using System.Net;

namespace PersonalWebsite.Controllers
{
    public class ToolsController : ThemedController
    {
        private readonly ILogger<ToolsController> _logger;
        private readonly IMemoryCache _memoryCache;

        public ToolsController(ILogger<ToolsController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }
        
        public IActionResult ChatColor() => View();

        public async Task<IActionResult> Lol()
        {
            const string cacheKey = "GoogleCloudRanges";

            if (!_memoryCache.TryGetValue(cacheKey, out List<IPNetwork> ranges))
            {
                _logger.LogInformation("Cache miss, fetching Google Cloud IP list");

                using var httpClient = new HttpClient();
                var response = await httpClient.GetFromJsonAsync<GoogleIpRanges>("https://www.gstatic.com/ipranges/cloud.json");

                if (response is null)
                    return StatusCode(500);

                ranges = new();

                foreach (var range in response.Prefixes) 
                {
                    if (range.Ipv4Prefix is not null)
                        ranges.Add(IPNetwork.Parse(range.Ipv4Prefix));
                    else if (range.Ipv6Prefix is not null)
                        ranges.Add(IPNetwork.Parse(range.Ipv6Prefix));
                }

                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddDays(7));

                _memoryCache.Set(cacheKey, ranges, cacheOptions);
            }

            foreach (var range in ranges)
            {
                if (range.Contains(HttpContext.Connection.RemoteIpAddress!))
                {
                    _logger.LogInformation("Requested from Discordbot");
                    return Redirect("~/img/andrew.jpg");
                }
            }

            return View();
        }
    }
}
