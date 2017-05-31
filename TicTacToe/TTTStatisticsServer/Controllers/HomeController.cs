using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using TTTStatisticsLibrary;
using TTTStatisticsServer.Interfaces;
using TTTStatisticsServer.Models;

namespace TTTStatisticsServer.Controllers
{
    public class HomeController : Controller
    {
        private IStatisticsModel statisticsModel;

        public HomeController() : base()
        {
            statisticsModel = new StatisticsModel();
        }

        public HomeController(IStatisticsModel statisticsModel) : base()
        {
            this.statisticsModel = statisticsModel;
        }

        [HttpGet]
        public ViewResult Index()
        {
            List<Statistic> statisticsList = statisticsModel.GetStatisticsList();
            ViewBag.HumanPercent = statisticsModel.CalculatePlayerPercent(statisticsList, Player.Human);
            ViewBag.ComputerPercent = statisticsModel.CalculatePlayerPercent(statisticsList, Player.Computer);
            ViewBag.TicPercent = statisticsModel.CalculateSidePercent(statisticsList, GameState.TicWon);
            ViewBag.TacPercent = statisticsModel.CalculateSidePercent(statisticsList, GameState.TacWon);
            return View(statisticsList);
        }

        [HttpPost]
        public string GetStatistics()
        {
            return statisticsModel.ToJsonString();
        }

        [HttpPost]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetStatistics(string jsonString)
        {
            statisticsModel.AddStatistics(jsonString);
        }
    }
}