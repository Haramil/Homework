using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace TicTacToe
{
    static class StatisticsWrapper
    {
        public static void SendGameResult(string uri, Statistics gameResult)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.UploadString(uri, JsonConvert.SerializeObject(gameResult));
            }
        }

        public static List<Statistics> GetStatistics(string uri)
        {
            using (WebClient webClient = new WebClient())
            {
                return JsonConvert.DeserializeObject<List<Statistics>>(webClient.UploadString(uri, null));
            }
        }
    }
}
