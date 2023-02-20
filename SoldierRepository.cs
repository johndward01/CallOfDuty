using CallOfDuty.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CallOfDuty
{
    public static class SoldierRepository
    {
        public static Soldier GetSoldierName(string gamertag)
        {
            var client = new RestSharp.RestClient($"https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/{gamertag}/act");

            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", "e26ce70479msh862bb9d83cedcf3p16d800jsnb50c1d29c253");

            request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");

            IRestResponse response = client.Execute(request);

            var soldier = new Soldier();
            
            if(response == null)
            {
                return null;
            }
            return soldier;
        }
        
        public static Soldier GetPlayerStats(IRestResponse response)
        {            

            var brObj = JObject.Parse(response.Content).GetValue("br");

            var soldierWins = brObj["wins"];
            var soldierKills = brObj["kills"];
            var soldierKdratio = brObj["kdRatio"];
            var soldierDowns = brObj["downs"];
            var soldierTopTwentyFive = brObj["topTwentyFive"];
            var soldierObjtime = brObj["objTime"];
            var soldierTopTen = brObj["topTen"];
            var soldierContracts = brObj["contracts"];
            var soldierRevives = brObj["revives"];
            var soldierTopFive = brObj["topFive"];
            var soldierScore = brObj["score"];
            var soldierTimeplayed = brObj["timePlayed"];
            var soldierGamesplayed = brObj["gamesPlayed"];
            var soldierScoreperminute = brObj["scorePerMinute"];
            var soldierDeaths = brObj["deaths"];

            var soldier = new Soldier()
            {
                Wins = (double)soldierWins,
                Kills = (double)soldierKills,
                KdRatio = (double)soldierKdratio,
                Downs = (double)soldierDowns,
                TopTwentyFive = (double)soldierTopTwentyFive,
                ObjTime = (double)soldierObjtime,
                TopTen = (double)soldierTopTen,
                Contracts = (double)soldierContracts,
                Revives = (double)soldierRevives,
                TopFive = (double)soldierTopFive,
                Score = (double)soldierScore,
                TimePlayed = (double)soldierTimeplayed,
                GamesPlayed = (double)soldierGamesplayed,
                ScorePerMinute = (double)soldierScoreperminute,
                Deaths = (double)soldierDeaths,
            };

            return soldier;
        }
    }
}
