using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Controllers
{
	public class StatusController : Controller
	{
		public IActionResult Http404() => View();
	}
}
