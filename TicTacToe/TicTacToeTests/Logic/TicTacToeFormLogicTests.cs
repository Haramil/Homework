using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TicTacToeTests;
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
        /// Юнит-тест для метода StartGame.
        /// Игра с компьютером, первым ходит компьютер.
        /// Свойство CurrentSideState должно указывать на ход ноликов (CellState.Tac)
        /// </summary>
        [TestMethod]
        public void StartGame_ComputerVsPlayer_CurrentSideIsTac()
        {
            // Arrange
            var logic = Test.CreateLogic();

            // Act
            logic.StartGame(true, true);

            // Assert
            Assert.AreEqual(logic.CurrentSideState, CellState.Tac);
        }

        /// <summary>
        /// Юнит-тест для метода StartGame.
        /// Игра с компьютером, первым ходит компьютер.
        /// При вызове метода StartGame должен выполниться метод ComputerGame, который осуществляет первый ход компьютера.
        /// </summary>
        [TestMethod]
        public void StartGame_ComputerVsPlayer_ComputerMoveDone()
        {
            // Arrange
            var logic = Test.CreateLogic();

            // Act
            logic.StartGame(true, true);

            // Assert
            Assert.AreEqual(logic.CellList.Count(c => c.CellState != CellState.Empty || c.CellState == CellState.Tic), 1);
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
            var logic = Test.CreateLogic();

            // Act
            logic.StartGame(false, false);

            // X |   | 
            //-----------
            //   |   |
            //-----------
            //   |   |   
            logic.PlayerMove(0);

            // X |   | 
            //-----------
            // O |   |
            //-----------
            //   |   |   
            logic.PlayerMove(3);

            // X | X | 
            //-----------
            // O |   |
            //-----------
            //   |   |   
            logic.PlayerMove(1);

            // X | X | 
            //-----------
            // O |   |
            //-----------
            // O |   |   
            logic.PlayerMove(6);

            // X | X | X
            //-----------
            // O |   |
            //-----------
            // O |   |   
            logic.PlayerMove(2);

            // Assert
            Assert.AreEqual(logic.GameState, GameState.TicWon);
        }

        /// <summary>
        /// Юнит-тест для метода StopGame
        /// Принуждённое завершение игры двух игроков победой ноликов
        /// Результат игры должен быть GameState.TacWon (победа ноликов)
        /// </summary>
        [TestMethod]
        public void StopGame_ForcedFinish_TacWon()
        {
            // Arrange
            var logic = Test.CreateLogic();

            // Act
            logic.StartGame(false, false);
            logic.StopGame(GameState.TacWon);

            // Assert
            Assert.AreEqual(logic.GameState, GameState.TacWon);
        }
    }
}
