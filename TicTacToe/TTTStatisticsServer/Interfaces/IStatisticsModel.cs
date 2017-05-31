using System.Collections.Generic;
using TTTStatisticsLibrary;

namespace TTTStatisticsServer.Interfaces
{
    /// <summary>
    /// Интерфейс модели данных - статистики игры
    /// </summary>
    public interface IStatisticsModel
    {
        /// <summary>
        /// Считывает статистику из БД
        /// </summary>
        /// <returns>Список со статистикой</returns>
        List<Statistic> GetStatisticsList();

        /// <summary>
        /// Добавляет статистику сыгранной игры в БД
        /// </summary>
        /// <param name="jsonString">Статистика сыгранной игры в виде JSON-строки</param>
        void AddStatistics(string jsonString);

        /// <summary>
        /// Преобразует данные о статистике из БД в JSON-строку
        /// </summary>
        /// <returns>JSON-строка</returns>
        string ToJsonString();

        /// <summary>
        /// Подсчитывает процент побед человека или компьютера
        /// </summary>
        /// <param name="statisticsList">Статистика</param>
        /// <param name="player">Чей процент считать</param>
        /// <returns>Процент побед</returns>
        int CalculatePlayerPercent(List<Statistic> statisticsList, Player player);

        /// <summary>
        /// Подсчитывает процент побед крестиков или ноликов (или процент ничьих)
        /// </summary>
        /// <param name="statisticsList">Статистика</param>
        /// <param name="gameState">Чей процент считать (если GameState.Draw, то ничьи)</param>
        /// <returns>Процент побед</returns>
        int CalculateSidePercent(List<Statistic> statisticsList, GameState gameState);
    }
}
