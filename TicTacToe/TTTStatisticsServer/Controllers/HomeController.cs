using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using TTTStatisticsLibrary;
using TTTStatisticsServer.Models;

namespace TTTStatisticsServer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            List<Statistics> statisticsList = StatisticsModels.GetStatisticsList();
            ViewBag.HumanPercent = StatisticsModels.CalculatePlayerPercent(statisticsList, Player.Human);
            ViewBag.ComputerPercent = StatisticsModels.CalculatePlayerPercent(statisticsList, Player.Computer);
            ViewBag.TicPercent = StatisticsModels.CalculateSidePercent(statisticsList, GameState.TicWon);
            ViewBag.TacPercent = StatisticsModels.CalculateSidePercent(statisticsList, GameState.TacWon);
            return View(statisticsList);
        }

        [HttpPost]
        public string GetStatistics()
        {
            return StatisticsModels.ReadJsonFile();
        }

        [HttpPost]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetStatistics(string jsonString)
        {
            StatisticsModels.AddStatistics(jsonString);
        }
    }
}