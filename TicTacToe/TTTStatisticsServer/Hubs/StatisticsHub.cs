using Microsoft.AspNet.SignalR;

namespace TTTStatisticsServer.Hubs
{
    public class StatisticsHub : Hub
    {
        public static void Broadcast(string jsonStatistics, int playerPercent, int computerPercent, 
            int ticPercent, int tacPercent)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<StatisticsHub>();
            // Call the addStatistics method to update clients.
            hubContext.Clients.All.addStatistics(jsonStatistics, playerPercent, computerPercent, ticPercent, tacPercent);
        }
    }
}