using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TTTStatisticsLibrary;
using TTTStatisticsServer.Interfaces;

namespace TTTStatisticsServer.Controllers.Tests
{
    /// <summary>
    /// Юнит-тесты для класса HomeController
    /// </summary>
    [TestClass]
    public class HomeControllerTests
    {
        /// <summary>
        /// Stub-класс, реализующий интерфейс IStatisticsModel
        /// </summary>
        private class StatisticsModelStub : IStatisticsModel
        {
            /// <summary>
            /// Список статистики (замена статистики, считываемой из БД)
            /// </summary>
            private List<Statistic> testStatisticsList;

            /// <summary>
            /// Конструктор, который принимает список статистики
            /// </summary>
            /// <param name="statisticsList">Список статистики</param>
            public StatisticsModelStub(List<Statistic> statisticsList)
            {
                testStatisticsList = statisticsList;
            }

            /// <summary>
            /// Считывает статистику из БД
            /// </summary>
            /// <returns>Список со статистикой</returns>
            public List<Statistic> GetStatisticsList()
            {
                // Возвращает список статистики testStatisticsList
                return testStatisticsList;
            }

            /// <summary>
            /// Добавляет статистику сыгранной игры в БД
            /// </summary>
            /// <param name="jsonString">Статистика сыгранной игры в виде JSON-строки</param>
            public void AddStatistics(string jsonString)
            {
                // Добавление статистики сыгранной игры в БД
            }

            /// <summary>
            /// Преобразует данные о статистике из БД в JSON-строку
            /// </summary>
            /// <returns>JSON-строка</returns>
            public string ToJsonString()
            {
                // Преобразование статистики из БД в строку JSON
                return string.Empty;
            }

            /// <summary>
            /// Подсчитывает процент побед человека или компьютера
            /// </summary>
            /// <param name="statisticsList">Статистика</param>
            /// <param name="player">Чей процент считать</param>
            /// <returns>Процент побед</returns>
            public int CalculatePlayerPercent(List<Statistic> statisticsList, Player player)
            {
                // Возвращает 0
                return 0;
            }

            /// <summary>
            /// Подсчитывает процент побед крестиков или ноликов (или процент ничьих)
            /// </summary>
            /// <param name="statisticsList">Статистика</param>
            /// <param name="gameState">Чей процент считать (если GameState.Draw, то ничьи)</param>
            /// <returns>Процент побед</returns>
            public int CalculateSidePercent(List<Statistic> statisticsList, GameState gameState)
            {
                // Возвращает 0
                return 0;
            }
        }

        /// <summary>
        /// Юнит-тест для метода Index.
        /// Метод создаёт объект класса ViewResult, в качестве модели - список статистики, возвращаемый методом GetStatisticsList
        ///     Stub-объекта класса StatisticsModelStub
        /// Списки статистики testingStatisticsList и viewResult.Model должны совпадать
        /// </summary>
        [TestMethod]
        public void Index_WithStubModel_ReturnsValidView()
        {
            // Arrange
            var testingStatisticsList = new List<Statistic>();
            var statisticsModelStub = new StatisticsModelStub(testingStatisticsList);
            var homeController = new HomeController(statisticsModelStub);

            // Act
            var viewResult = homeController.Index();

            // Assert
            ReferenceEquals(testingStatisticsList, viewResult.Model);
        }
    }
}
