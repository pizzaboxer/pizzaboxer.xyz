using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Controllers
{
	public class StatusController : ThemedController
	{
		public IActionResult Http404() => View();
	}
}
