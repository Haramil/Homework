using System.Runtime.CompilerServices;
using System.Web.Mvc;
using TTTStatisticsServer.Models;

namespace TTTStatisticsServer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public ViewResult Index()
        {

            return View(StatisticsModels.GetFullStatistics());
        }

        [HttpPost]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public string GetStatistics()
        {
            return StatisticsModels.SerializeFullStatistics();
        }

        [HttpPost]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetStatistics(string jsonString)
        {
            StatisticsModels.AddStatistics(jsonString);
        }
    }
}