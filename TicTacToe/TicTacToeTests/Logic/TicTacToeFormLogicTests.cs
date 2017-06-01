using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TicTacToe.Exceptions;
using TicTacToe.Interfaces;
using TTTStatisticsLibrary;

namespace TicTacToe.Logic.Tests
{
    /// <summary>
    /// Юнит-тесты для класса TicTacToeFormLogic
    /// </summary>
    [TestClass]
    public class TicTacToeFormLogicTests
    {
        /// <summary>
        /// Создает экземпляр класса TicTacToeFormLogic для проведения юнит-тестов
        /// </summary>
        /// <returns>Рабочий экземпляр класса TicTacToeFormLogic</returns>
        private static TicTacToeFormLogic CreateLogic()
        {
            var fixture = new Fixture();
            var testCellButtonsDict = new Dictionary<byte, Button>();
            for (int i = 0; i < 9; i++)
                testCellButtonsDict.Add((byte)i, fixture.Build<Button>().OmitAutoProperties().Create());
            var testLabel = fixture.Build<Label>().OmitAutoProperties().Create();
            var testTextBox = fixture.Build<TextBox>().OmitAutoProperties().Create();
            var testImage = new Bitmap(1, 1);
            var statisticsWrapperMock = new Mock<IStatisticsWrapper>();
            statisticsWrapperMock.Setup(w => w.SendGameResult(It.IsAny<string>(), It.IsAny<Statistic>()));
            statisticsWrapperMock.Setup(w => w.GetStatistics(It.IsAny<string>())).Returns(new Fixture().Create<List<Statistic>>());
            return new TicTacToeFormLogic(testCellButtonsDict, testLabel, testLabel, testTextBox,
                testImage, testImage, testImage, statisticsWrapperMock.Object);
        }

        /// <summary>
        /// Юнит-тест для метода StartGame.
        /// Игра с компьютером, первым ходит компьютер.
        /// Свойство CurrentSideState должно указывать на ход ноликов (CellState.Tac), т.к. крестики уже сходили
        /// </summary>
        [TestMethod]
        public void StartGame_ComputerVsPlayer_CurrentSideIsTac()
        {
            // Arrange
            var logic = CreateLogic();

            // Act
            logic.StartGame(true, true);

            // Assert
            Assert.AreEqual(logic.CurrentSideState, CellState.Tac);
        }

        /// <summary>
        /// Юнит-тест для метода StartGame.
        /// Игра с компьютером, первым ходит компьютер.
        /// При вызове метода StartGame должен выполниться метод ComputerGame, который осуществляет первый ход компьютера
        /// </summary>
        [TestMethod]
        public void StartGame_ComputerVsPlayer_ComputerMoveDone()
        {
            // Arrange
            var logic = CreateLogic();

            // Act
            logic.StartGame(true, true);

            // Assert
            Assert.IsTrue(logic.CellList.Count(c => c.CellState != CellState.Empty) == 1 &&
                logic.CellList.Any(c => c.CellState == CellState.Tic));
        }
        
        /// <summary>
        /// Юнит-тест для метода PlayerMove.
        /// Игра двух игроков.
        /// При определённых ходах игра должна завершиться победой крестиков
        /// </summary>
        [TestMethod]
        public void PlayerMove_PlayerVsPlayer_TicWon()
        {
            // Arrange
            var logic = CreateLogic();

            // Act
            logic.StartGame(false, false);

            // X |   | 
            //---+---+---
            //   |   |
            //---+---+---
            //   |   |   
            logic.PlayerMove(0);

            // X |   | 
            //---+---+---
            // O |   |
            //---+---+---
            //   |   |   
            logic.PlayerMove(3);

            // X | X | 
            //---+---+---
            // O |   |
            //---+---+---
            //   |   |   
            logic.PlayerMove(1);

            // X | X | 
            //---+---+---
            // O |   |
            //---+---+---
            // O |   |   
            logic.PlayerMove(6);

            // X | X | X
            //---+---+---
            // O |   |
            //---+---+---
            // O |   |   
            logic.PlayerMove(2);

            // Assert
            Assert.AreEqual(logic.GameState, GameState.TicWon);
        }

        /// <summary>
        /// Юнит-тест для метода StopGame.
        /// Принуждённое завершение игры двух игроков победой ноликов.
        /// Результат игры должен быть GameState.TacWon (победа ноликов)
        /// </summary>
        [TestMethod]
        public void StopGame_ForcedFinish_TacWon()
        {
            // Arrange
            var logic = CreateLogic();

            // Act
            logic.StartGame(false, false);
            logic.StopGame(GameState.TacWon);

            // Assert
            Assert.AreEqual(logic.GameState, GameState.TacWon);
        }

        /// <summary>
        /// Юнит-тест для метода ComputerMove.
        /// Игра человека и человека.
        /// При вызове метода ComputerMove компьютер должен сделать первый ход (за крестики)
        /// </summary>
        [TestMethod]
        public void ComputerMove_PlayerVsPlayer_ComputerMoveDone()
        {
            // Arrange
            var logic = CreateLogic();

            // Act
            logic.StartGame(false, false);
            logic.ComputerMove();

            // Assert
            Assert.IsTrue(logic.CellList.Count(c => c.CellState != CellState.Empty) == 1 &&
                logic.CellList.Any(c => c.CellState == CellState.Tic));
        }

        /// <summary>
        /// Юнит-тест для метода PlayerMove.
        /// Игра человека и человека.
        /// При попытке сходить в занятую ячейку должно быть вызвано исключение CellNotEmptyException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CellNotEmptyException))]
        public void PlayerMove_PlayerVsPlayer_CellNotEmpty()
        {
            // Arrange
            var logic = CreateLogic();
            var cellNum = (byte)(new Random().Next(0, 9));

            // Act
            logic.StartGame(false, false);
            logic.PlayerMove(cellNum);
            logic.PlayerMove(cellNum);

            // Assert
            // Ожидается CellNotEmptyException
        }

        /// <summary>
        /// Юнит-тест для метода PlayerMove.
        /// Игра не начата, ход игрока.
        /// При попытке сходить до начала игры должно быть вызвано исключение GameNotInProgressException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GameNotInProgressException))]
        public void PlayerMove_PlayerVsPlayer_GameNotInProgress()
        {
            // Arrange
            var logic = CreateLogic();
            var cellNum = (byte)(new Random().Next(0, 9));

            // Act
            logic.PlayerMove(cellNum);

            // Assert
            // Ожидается GameNotInProgressException
        }

        /// <summary>
        /// Юнит-тест для метода PlayerMove.
        /// Игра человека и человека, игрок делает ход.
        /// Ход игрока должен выполниться (ячейка, куда он сходил, должна стать занятой крестиком)
        /// </summary>
        [TestMethod]
        public void PlayerMove_PlayerVsPlayer_PlayerMoveDone()
        {
            // Arrange
            var logic = CreateLogic();

            // Act
            logic.StartGame(false, false);
            logic.PlayerMove(4);

            // Assert
            Assert.AreEqual(logic.CellList[4].CellState, CellState.Tic);
        }
    }
}
