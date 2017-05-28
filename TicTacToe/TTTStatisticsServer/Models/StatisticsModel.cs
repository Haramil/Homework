using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using TTTStatisticsLibrary;
using TTTStatisticsServer.Hubs;

namespace TTTStatisticsServer.Models
{
    public static class StatisticsModel
    {
        public static List<Statistics> GetStatisticsList()
        {
            return JsonConvert.DeserializeObject<List<Statistics>>(ReadJsonFile()) ?? new List<Statistics>();
        }

        public static string ReadJsonFile()
        {
            try
            {
                return File.ReadAllText(HostingEnvironment.ApplicationPhysicalPath + @"\App_Data\Statistics.json");
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void AddStatistics(string jsonString)
        {
            List<Statistics> statistics = GetStatisticsList();
            statistics.Add(JsonConvert.DeserializeObject<Statistics>(jsonString));
            File.WriteAllText(HostingEnvironment.ApplicationPhysicalPath + @"\App_Data\Statistics.json",
                JsonConvert.SerializeObject(statistics));
            StatisticsHub.Broadcast(jsonString, CalculatePlayerPercent(statistics, Player.Human),
                CalculatePlayerPercent(statistics, Player.Computer), 
                CalculateSidePercent(statistics, GameState.TicWon), 
                CalculateSidePercent(statistics, GameState.TacWon));
        }

        public static int CalculatePlayerPercent(List<Statistics> statisticsList, Player player)
        {
            if (statisticsList.Count == 0) return 0;
            return statisticsList.Count(s => (s.TicPlayer == player && s.GameResult == GameState.TicWon) || 
                (s.TacPlayer == player && s.GameResult == GameState.TacWon)) * 100 / statisticsList.Count;
        }

        public static int CalculateSidePercent(List<Statistics> statisticsList, GameState gameState)
        {
            if (statisticsList.Count == 0) return 0;
            return statisticsList.Count(s => s.GameResult == gameState) * 100 / statisticsList.Count;
        }
    }
}