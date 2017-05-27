using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using TTTStatisticsLibrary;

namespace TTTStatisticsServer.Models
{
    public static class StatisticsModels
    {
        public static FullStatistics GetFullStatistics()
        {
            List<Statistics> statisticsList = GetStatisticsList();
            return new FullStatistics
            {
                StatisticsList = statisticsList,
                PlayerWinPercent = statisticsList.Count == 0 ? 0 : statisticsList.Count(s => 
                    ((s.GameResult == GameState.TicWon && s.TicPlayer == Player.Human) || 
                    (s.GameResult == GameState.TacWon && s.TacPlayer == Player.Human))) * 100 / 
                    statisticsList.Count
            };
        }

        private static List<Statistics> GetStatisticsList()
        {
            return JsonConvert.DeserializeObject<List<Statistics>>(ReadJsonFile()) ?? new List<Statistics>();
        }

        private static string ReadJsonFile()
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

        public static string SerializeFullStatistics()
        {
            return JsonConvert.SerializeObject(GetFullStatistics());
        }

        public static void AddStatistics(string jsonString)
        {
            List<Statistics> statistics = GetStatisticsList();
            statistics.Add(JsonConvert.DeserializeObject<Statistics>(jsonString));
            File.WriteAllText(HostingEnvironment.ApplicationPhysicalPath + @"\App_Data\Statistics.json",
                JsonConvert.SerializeObject(statistics));
        }
    }
}