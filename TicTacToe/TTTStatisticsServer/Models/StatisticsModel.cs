using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TTTStatisticsLibrary;
using TTTStatisticsServer.Hubs;
using TTTStatisticsServer.Interfaces;

namespace TTTStatisticsServer.Models
{
    /// <summary>
    /// Модель StatisticsModel для работы со статистикой
    /// </summary>
    public class StatisticsModel : IStatisticsModel
    {
        /// <summary>
        /// Считывает статистику из БД
        /// </summary>
        /// <returns>Список со статистикой</returns>
        public List<Statistic> GetStatisticsList()
        {
            using (StatisticsContext db = new StatisticsContext())
            {
                db.Statistics.Load();
                return db.Statistics.Local.ToList();
            }
        }

        /// <summary>
        /// Добавляет статистику сыгранной игры в БД
        /// </summary>
        /// <param name="jsonString">Статистика сыгранной игры в виде JSON-строки</param>
        public void AddStatistics(string jsonString)
        {
            using (StatisticsContext db = new StatisticsContext())
            {
                db.Statistics.Add(JsonConvert.DeserializeObject<Statistic>(jsonString));
                db.SaveChanges();
            }
            List<Statistic> statistics = GetStatisticsList();
            // Отправка статистики всем клиентам
            StatisticsHub.Broadcast(jsonString, CalculatePlayerPercent(statistics, Player.Human),
                CalculatePlayerPercent(statistics, Player.Computer),
                CalculateSidePercent(statistics, GameState.TicWon),
                CalculateSidePercent(statistics, GameState.TacWon));
        }

        /// <summary>
        /// Преобразует данные о статистике из БД в JSON-строку
        /// </summary>
        /// <returns>JSON-строка</returns>
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(GetStatisticsList());
        }

        /// <summary>
        /// Подсчитывает процент побед человека или компьютера
        /// </summary>
        /// <param name="statisticsList">Статистика</param>
        /// <param name="player">Чей процент считать</param>
        /// <returns>Процент побед</returns>
        public int CalculatePlayerPercent(List<Statistic> statisticsList, Player player)
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
        public int CalculateSidePercent(List<Statistic> statisticsList, GameState gameState)
        {
            if (statisticsList.Count == 0) return 0;
            return statisticsList.Count(s => s.GameResult == gameState) * 100 / statisticsList.Count;
        }
    }
}