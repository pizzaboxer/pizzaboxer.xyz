using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Models;
using System.Diagnostics;

namespace PersonalWebsite.Controllers
{
    public class HomeController : ThemedController
    {
        public IActionResult Index() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}