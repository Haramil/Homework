using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Logic;
using Ploeh.AutoFixture;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Moq;
using TTTStatisticsLibrary;
using TicTacToeTests;

namespace TicTacToe.Logic.Tests
{
    [TestClass]
    public class TicTacToeFormLogicTests
    {
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

        [TestMethod]
        public void FinishGame_PlayerVsPlayer_TicWon()
        {
            // Arrange
            var logic = Test.CreateLogic();

            // Act
            logic.StartGame(false, false);
            logic.PlayerMove(0);
            logic.PlayerMove(3);
            logic.PlayerMove(1);
            logic.PlayerMove(6);
            logic.PlayerMove(2);

            // Assert
            Assert.AreEqual(logic.GameState, GameState.TicWon);
        }
    }
}
