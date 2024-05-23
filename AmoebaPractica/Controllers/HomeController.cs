using Microsoft.AspNetCore.Mvc;

namespace AmoebaPractica.Controllers
{
	public class HomeController : Controller
	{
	

		public IActionResult Index()
		{
			return View();
		}

		
	}
}
