﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_IntroDemo.Models.Product;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MVC_IntroDemo.Controllers
{
	public class ProductController : Controller
	{
 		//there is no database, that is why this private field is located here
		private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Ham",
				Price = 5.50
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Bread",
				Price = 1.50
			}
		};

		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
			ViewBag.Keyword = keyword;
			return View(_products);
		}

		public IActionResult ById(int id)
		{
			var product = _products.FirstOrDefault(pr => pr.Id == id);

			if (product == null)
			{
				return BadRequest();
			}
			return View(product);
		}

		public IActionResult AllAsJson()
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true
			};

			return Json(_products, options);
		}

		public IActionResult AllAsText()
		{
			string text = string.Empty;

			foreach(var product in _products)
{
				text += $"Product {@product.Id}: {@product.Name} - {@product.Price} lv.";
				text += "\r\n";
			}
			return Content(text);
		}


		public IActionResult AllAsTextFile()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var product in _products)
			{
				sb.AppendLine($"Product {@product.Id}: {@product.Name} - {@product.Price} lv.");
			}
			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

			return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
		}
	}
}
