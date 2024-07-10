using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PersonalWebsite.Models;

namespace PersonalWebsite.Controllers
{
    public class ThemedController : Controller
    {
        public override ViewResult View()
        {
            ViewData["LoadBackground"] = true;
            
            var header = Request.Headers.Referer;
            if (header != StringValues.Empty)
                ViewData["LoadBackground"] = !header[0].Contains(Request.Host.ToString());

            return base.View();
        }
    }
}
