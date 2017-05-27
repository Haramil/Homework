using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using TTTStatisticsLibrary;

namespace TicTacToe
{
    static class StatisticsWrapper
    {
        public static void SendGameResult(string uri, Statistics gameResult)
        {
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection postDataCollection = new NameValueCollection();
                postDataCollection.Add("jsonString", JsonConvert.SerializeObject(gameResult));
                webClient.UploadValues(uri + @"/Home/SetStatistics", postDataCollection);
            }
        }

        public static FullStatistics GetStatistics(string uri)
        {
            using (WebClient webClient = new WebClient())
            {
                return JsonConvert.DeserializeObject<FullStatistics>(Encoding.UTF8.GetString(
                    webClient.UploadValues(uri + @"/Home/GetStatistics", new NameValueCollection())));
            }
        }
    }
}
