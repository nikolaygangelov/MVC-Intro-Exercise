using Microsoft.AspNetCore.Mvc;
using MVC_IntroDemo.Models;
using System.Diagnostics;

namespace MVC_IntroDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			ViewBag.Message = "Hello World";
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewBag.Message = "This is an ASP.NET Core MVC app.";
			return View();
		}

		public IActionResult Numbers()
		{
			return View();
		}

		[HttpGet]
		public IActionResult NumbersToN()
		{
			ViewBag.Count = 3;
			return View();
		}

		[HttpPost]
		public IActionResult NumbersToN(int count)
		{
			ViewBag.Count = count;
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}