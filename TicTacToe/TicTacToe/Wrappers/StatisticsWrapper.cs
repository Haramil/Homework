using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using TicTacToe.Interfaces;
using TTTStatisticsLibrary;

namespace TicTacToe.Wrappers
{
    /// <summary>
    /// Класс, служащий для отправки и получения статистики от сервера
    /// </summary>
    public class StatisticsWrapper : IStatisticsWrapper
    {
        /// <summary>
        /// Отправляет статистику сыгранной игры в формате JSON
        /// </summary>
        /// <param name="uri">URI сервера статистики</param>
        /// <param name="gameResult">Статистика игры</param>
        public void SendGameResult(string uri, Statistic gameResult)
        {
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection postDataCollection = new NameValueCollection();
                // Объект класса Statistics преобразуется в JSON-строку
                postDataCollection.Add("jsonString", JsonConvert.SerializeObject(gameResult));
                webClient.UploadValues(uri + @"/Home/SetStatistics", postDataCollection);
            }
        }

        /// <summary>
        /// Получает статистику сыгранных игр от сервера
        /// </summary>
        /// <param name="uri">URI сервера статистики</param>
        /// <returns>Статистика</returns>
        public List<Statistic> GetStatistics(string uri)
        {
            using (WebClient webClient = new WebClient())
            {
                return JsonConvert.DeserializeObject<List<Statistic>>(Encoding.UTF8.GetString(
                    webClient.UploadValues(uri + @"/Home/GetStatistics", new NameValueCollection())));
            }
        }
    }
}
