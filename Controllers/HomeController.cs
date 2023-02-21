using CallOfDuty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace CallOfDuty.Controllers
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
            var root = new Root();
            return View(root);
        }

        public IActionResult Search(Root form)
        {
            var client = new RestClient($"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/{form.data.username}/psn");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "074ffd9f62mshfab1a752b7e2342p1f409fjsnbc7bc16069e0");
            request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
            var response = client.Execute(request).Content;
            var root = JsonConvert.DeserializeObject<Root>(response);
            return View(root);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}