using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
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
                // Считывает статистику из БД и возвращает список List<Statistic>
                return testStatisticsList;
            }

            /// <summary>
            /// Добавляет статистику сыгранной игры в БД
            /// </summary>
            /// <param name="jsonString">Статистика сыгранной игры в виде JSON-строки</param>
            public void AddStatistics(string jsonString)
            {
                // Добавление статистики сыгранной игры в БД
                testStatisticsList.Add(JsonConvert.DeserializeObject<Statistic>(jsonString));
            }

            /// <summary>
            /// Преобразует данные о статистике из БД в JSON-строку
            /// </summary>
            /// <returns>JSON-строка</returns>
            public string ToJsonString()
            {
                // Преобразование статистики из БД в строку JSON
                return JsonConvert.SerializeObject(testStatisticsList);
            }

            /// <summary>
            /// Подсчитывает процент побед человека или компьютера
            /// </summary>
            /// <param name="statisticsList">Статистика</param>
            /// <param name="player">Чей процент считать</param>
            /// <returns>Процент побед</returns>
            public int CalculatePlayerPercent(List<Statistic> statisticsList, Player player)
            {
                return new Random().Next(0, 101);
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
                return new Random().Next(0, 101);
            }
        }

        /// <summary>
        /// Юнит-тест для метода Index.
        /// Метод передаёт в представление список статистики, полученный из модели (Stub-объекта StatisticsModelStub).
        /// Списки статистики testingStatisticsList и viewResult.Model должны совпадать
        /// </summary>
        [TestMethod]
        public void Index_WithStubModel_ReturnsViewWithValidModel()
        {
            // Arrange
            var testingStatisticsList = new Fixture().Create<List<Statistic>>();
            var statisticsModelStub = new StatisticsModelStub(testingStatisticsList);
            var homeController = new HomeController(statisticsModelStub);

            // Act
            var viewResult = homeController.Index();

            // Assert
            CollectionAssert.AreEqual(testingStatisticsList, viewResult.Model as List<Statistic>);
        }

        /// <summary>
        /// Юнит-тест для метода SetStatistics.
        /// Метод добавляет полученную статистику в список статистики модели.
        /// В список testingStatisticsList должна быть добавлена новая статистика (проверяется совпадение даты игры)
        /// </summary>
        [TestMethod]
        public void SetStatistics_WithStubModel_StatisticsAdded()
        {
            // Arrange
            var fixture = new Fixture();
            var testingStatisticsList = fixture.Create<List<Statistic>>();
            var date = fixture.Create<DateTime>();
            var addingStatistic = fixture.Build<Statistic>().With(s => s.GameDate, date).Create();
            var jsonString = JsonConvert.SerializeObject(addingStatistic);
            var statisticsModelStub = new StatisticsModelStub(testingStatisticsList);
            var homeController = new HomeController(statisticsModelStub);

            // Act
            homeController.SetStatistics(jsonString);

            // Assert
            Assert.AreEqual(addingStatistic.GameDate, testingStatisticsList.Last().GameDate);
        }
    }
}
