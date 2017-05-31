using System.Collections.Generic;
using TTTStatisticsLibrary;

namespace TicTacToe.Interfaces
{
    /// <summary>
    /// Интерфейс для работы со статистикой
    /// </summary>
    public interface IStatisticsWrapper
    {
        /// <summary>
        /// Отправляет статистику сыгранной игры
        /// </summary>
        /// <param name="uri">URI сервера статистики</param>
        /// <param name="gameResult">Статистика игры</param>
        void SendGameResult(string uri, Statistic gameResult);

        /// <summary>
        /// Получает статистику сыгранных игр от сервера
        /// </summary>
        /// <param name="uri">URI сервера статистики</param>
        /// <returns>Статистика</returns>
        List<Statistic> GetStatistics(string uri);
    }
}
