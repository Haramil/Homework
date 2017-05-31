using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;
using TicTacToe.Interfaces;
using TTTStatisticsLibrary;

namespace TicTacToe.Logic
{
    /// <summary>
    /// Представляет логику игры "Крестики-нолики"
    /// </summary>
    abstract class TicTacToeLogic : IGameLogic
    {
        /// <summary>
        /// Представляет сведения о ячейке поля игры
        /// </summary>
        protected class Cell
        {
            /// <summary>
            /// Указывает, какие линии занимает ячейка
            /// </summary>
            // 0 - верхняя горизонталь
            // 1 - средняя горизонталь
            // 2 - нижняя горизонталь
            // 3 - левая вертикаль
            // 4 - средняя вертикаль
            // 5 - правая вертикаль
            // 6 - главная диагональ
            // 7 - побочная диагональ
            public byte[] CellLines { get; set; }

            /// <summary>
            /// Указывает состояние ячейки
            /// </summary>
            public CellState CellState { get; set; }

            /// <summary>
            /// Инициализирует новый экземпляр класса Cell - пустую ячейку
            /// </summary>
            /// <param name="lines">Какие линии занимает ячейка</param>
            public Cell(byte[] lines)
            {
                CellLines = lines;
                CellState = CellState.Empty;
            }
        }

        /// <summary>
        /// Представляет список ячеек поля
        /// </summary>
        protected List<Cell> cellList;

        /// <summary>
        /// Представляет состояние каждой линии поля
        /// </summary>
        protected sbyte[] lineStates;

        /// <summary>
        /// Указывает, чей сейчас ход - крестиков или ноликов
        /// </summary>
        protected CellState currentSideState = CellState.Empty;

        /// <summary>
        /// Указывает состояние игры
        /// </summary>
        protected GameState gameState;

        /// <summary>
        /// Указывает, с кем играет игрок - с компьютером или с другим игроком
        /// </summary>
        protected bool isSinglePlayer;

        /// <summary>
        /// Указывает, кто ходит вторым - человек или компьютер
        /// </summary>
        protected bool isPlayerSecond;

        /// <summary>
        /// Инициализирует новый экземпляр класса TicTacToeLogic, заполняет список ячеек
        /// </summary>
        public TicTacToeLogic()
        {
            cellList = new List<Cell>();
            cellList.Add(new Cell(new byte[] { 0, 3, 6 }));
            cellList.Add(new Cell(new byte[] { 0, 4 }));
            cellList.Add(new Cell(new byte[] { 0, 5, 7 }));
            cellList.Add(new Cell(new byte[] { 1, 3 }));
            cellList.Add(new Cell(new byte[] { 1, 4, 6, 7 }));
            cellList.Add(new Cell(new byte[] { 1, 5 }));
            cellList.Add(new Cell(new byte[] { 2, 3, 7 }));
            cellList.Add(new Cell(new byte[] { 2, 4 }));
            cellList.Add(new Cell(new byte[] { 2, 5, 6 }));
        }

        /// <summary>
        /// Запускает игру
        /// </summary>
        /// <param name="isSinglePlayer">Указывает, с кем играет игрок - с компьютером или с другим игроком</param>
        /// <param name="isPlayerSecond">Указывает, кто ходит вторым - человек или компьютер</param>
        public abstract void StartGame(bool isSinglePlayer, bool isPlayerSecond);

        /// <summary>
        /// Останавливает игру
        /// </summary>
        /// <param name="finalState">Итоговое состояние игры</param>
        public abstract void StopGame(GameState finalState);

        /// <summary>
        /// Осуществляет обработку хода
        /// </summary>
        /// <param name="cellNum">Номер ячейки, в которую сходили</param>
        protected abstract void Move(int cellNum);

        /// <summary>
        /// Осуществляет ход игрока
        /// </summary>
        /// <param name="cellNum">Номер ячейки, в которую сходил игрок</param>
        public void PlayerMove(int cellNum)
        {
            Cell selectedCell = cellList[cellNum];
            if (gameState != GameState.InProgress) // Игра остановлена
                throw new GameNotInProgressException(gameState);
            else if (selectedCell.CellState != CellState.Empty) // Ячейка занята
                throw new CellNotEmptyException(selectedCell.CellLines[0], (byte)(selectedCell.CellLines[1] - 3));
            else
            {
                Move(cellNum);
                if (isSinglePlayer)
                    // Ход компьютера
                    ComputerMove();
            }
        }

        /// <summary>
        /// Осуществляет ход компьютера
        /// </summary>
        public void ComputerMove()
        {
            if (gameState == GameState.InProgress) // Игра в процессе
            {
                Random rand = new Random();
                // Находим все свободные ячейки
                IEnumerable<Cell> availableCells = cellList.Where(c => c.CellState == CellState.Empty);
                // Среди них находим важные ячейки
                IEnumerable<Cell> importantCells = availableCells.Where(c => CheckImportantCell(c));
                if (importantCells.Count() > 0)
                    Move(cellList.IndexOf(importantCells.ElementAt(rand.Next(0, importantCells.Count()))));
                else
                    Move(cellList.IndexOf(availableCells.ElementAt(rand.Next(0, availableCells.Count()))));
            }
        }

        /// <summary>
        /// Проверяет важность ячейки.
        /// Ячейка важная, если линии, которым она принадлежит, практически заполнены
        /// </summary>
        /// <param name="cell">Выбранная ячейка</param>
        /// <returns>true, если ячейка - важная</returns>
        private bool CheckImportantCell(Cell cell)
        {
            foreach (byte line in cell.CellLines)
                if (Math.Abs(lineStates[line]) == 2)
                    return true;
            return false;
        }
    }

    /// <summary>
    /// Возможные состояния ячейки
    /// </summary>
    enum CellState
    {
        /// <summary>
        /// Пустая ячейка
        /// </summary>
        Empty,

        /// <summary>
        /// Крестики
        /// </summary>
        Tic,

        /// <summary>
        /// Нолики
        /// </summary>
        Tac
    }

    
}
