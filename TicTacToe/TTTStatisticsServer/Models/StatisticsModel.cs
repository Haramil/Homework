using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using TTTStatisticsLibrary;
using TTTStatisticsServer.Hubs;

namespace TTTStatisticsServer.Models
{
    /// <summary>
    /// Модель StatisticsModel для работы со статистикой
    /// </summary>
    public static class StatisticsModel
    {
        /// <summary>
        /// Преобразует JSON-строку в список статистики
        /// </summary>
        /// <returns>Список со статистикой</returns>
        public static List<Statistic> GetStatisticsList()
        {
            return JsonConvert.DeserializeObject<List<Statistic>>(ReadJsonFile()) ?? new List<Statistic>();
        }

        /// <summary>
        /// Считывает JSON-файл со статистикой
        /// </summary>
        /// <returns>Строка JSON</returns>
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

        /// <summary>
        /// Добавляет статистику сыгранной игры в JSON-файл
        /// </summary>
        /// <param name="jsonString">Статистика сыгранной игры в виде JSON-строки</param>
        public static void AddStatistics(string jsonString)
        {
            List<Statistic> statistics = GetStatisticsList();
            statistics.Add(JsonConvert.DeserializeObject<Statistic>(jsonString));
            // Запись статистики в файл
            File.WriteAllText(HostingEnvironment.ApplicationPhysicalPath + @"\App_Data\Statistics.json",
                JsonConvert.SerializeObject(statistics));
            // Отправка статистики всем клиентам
            StatisticsHub.Broadcast(jsonString, CalculatePlayerPercent(statistics, Player.Human),
                CalculatePlayerPercent(statistics, Player.Computer), 
                CalculateSidePercent(statistics, GameState.TicWon), 
                CalculateSidePercent(statistics, GameState.TacWon));
        }

        /// <summary>
        /// Подсчитывает процент побед человека или компьютера
        /// </summary>
        /// <param name="statisticsList">Статистика</param>
        /// <param name="player">Чей процент считать</param>
        /// <returns>Процент побед</returns>
        public static int CalculatePlayerPercent(List<Statistic> statisticsList, Player player)
        {
            if (statisticsList.Count == 0) return 0;
            return statisticsList.Count(s => (s.TicPlayer == player && s.GameResult == GameState.TicWon) || 
                (s.TacPlayer == player && s.GameResult == GameState.TacWon)) * 100 / statisticsList.Count;
        }

        /// <summary>
        /// Подсчитывает процент побед крестиков или ноликов (или процент ничьих)
        /// </summary>
        /// <param name="statisticsList">Статистика</param>
        /// <param name="gameState">Чей процент считать (если GameState.Draw, то ничьи)</param>
        /// <returns>Процент побед</returns>
        public static int CalculateSidePercent(List<Statistic> statisticsList, GameState gameState)
        {
            if (statisticsList.Count == 0) return 0;
            return statisticsList.Count(s => s.GameResult == gameState) * 100 / statisticsList.Count;
        }
    }
}