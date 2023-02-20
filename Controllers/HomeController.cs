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
            var player = new Data();

            return View(player);
        }

        public IActionResult Search(Data player)
        {
            var client = new RestSharp.RestClient($"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/{player.username}/psn");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-RapidAPI-Key", "e26ce70479msh862bb9d83cedcf3p16d800jsnb50c1d29c253");
            request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
            var response = client.Execute(request).Content;
            var root = JsonConvert.DeserializeObject<Root>(response);

            return View(root);
            #region Jonathan Will's sandbox
            //IRestResponse response = client.Execute(request);

            //var brObj = JObject.Parse(response.Content).GetValue("br");

            //var soldierWins = brObj ["properties"]["wins"];
            //var soldierKills = brObj["kills"];
            //var soldierKdratio = brObj["kdRatio"];
            //var soldierDowns = brObj["downs"];
            //var soldierTopTwentyFive = brObj["topTwentyFive"];
            //var soldierObjtime = brObj["objTime"];
            //var soldierTopTen = brObj["topTen"];
            //var soldierContracts = brObj["contracts"];
            //var soldierRevives = brObj["revives"];
            //var soldierTopFive = brObj["topFive"];
            //var soldierScore = brObj["score"];
            //var soldierTimeplayed = brObj["timePlayed"];
            //var soldierGamesplayed = brObj["gamesPlayed"];
            //var soldierScoreperminute = brObj["scorePerMinute"];
            //var soldierDeaths = brObj["deaths"];

            //var soldier = new Soldier()
            //{
            //    Wins = (double)soldierWins,
            //    Kills = (double)soldierKills,
            //    KdRatio = (double)soldierKdratio,
            //    Downs = (double)soldierDowns,
            //    TopTwentyFive = (double)soldierTopTwentyFive,
            //    ObjTime = (double)soldierObjtime,
            //    TopTen = (double)soldierTopTen,
            //    Contracts = (double)soldierContracts,
            //    Revives = (double)soldierRevives,
            //    TopFive = (double)soldierTopFive,
            //    Score = (double)soldierScore,
            //    TimePlayed = (double)soldierTimeplayed,
            //    GamesPlayed = (double)soldierGamesplayed,
            //    ScorePerMinute = (double)soldierScoreperminute,
            //    Deaths = (double)soldierDeaths,
            //};

            #endregion
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