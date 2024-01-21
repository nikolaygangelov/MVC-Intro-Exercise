using Microsoft.AspNetCore.Mvc;
using MVC_IntroDemo.Models;
using System.Diagnostics;

namespace MVC_IntroDemo.Controllers
{
	//HomeController inherits Controller class 
 	//gives you access to Request, Response, ViewBag, ViewData, View, etc.
	public class HomeController : Controller
	{
 		//value of _logger is passed by constructor
   		//_logger keeps record of errors
		private readonly ILogger<HomeController> _logger;
  
		//using dependancy injection through constructor
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
