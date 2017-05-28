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
            List<Statistics> statisticsList = StatisticsModel.GetStatisticsList();
            ViewBag.HumanPercent = StatisticsModel.CalculatePlayerPercent(statisticsList, Player.Human);
            ViewBag.ComputerPercent = StatisticsModel.CalculatePlayerPercent(statisticsList, Player.Computer);
            ViewBag.TicPercent = StatisticsModel.CalculateSidePercent(statisticsList, GameState.TicWon);
            ViewBag.TacPercent = StatisticsModel.CalculateSidePercent(statisticsList, GameState.TacWon);
            return View(statisticsList);
        }

        [HttpPost]
        public string GetStatistics()
        {
            return StatisticsModel.ReadJsonFile();
        }

        [HttpPost]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetStatistics(string jsonString)
        {
            StatisticsModel.AddStatistics(jsonString);
        }
    }
}