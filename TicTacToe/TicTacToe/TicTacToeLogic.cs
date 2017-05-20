using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    abstract class TicTacToeLogic : IGameLogic
    {
        protected class Cell
        {
            public byte[] CellLines { get; set; }
            public CellState CellState { get; set; }

            public Cell(byte[] lines)
            {
                CellLines = lines;
                CellState = CellState.Empty;
            }
        }

        protected List<Cell> cellList;
        protected sbyte[] lineStates;
        protected CellState currentSideState = CellState.Empty;
        protected GameState gameState;

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

        public abstract void StartGame();
        public abstract void StopGame(GameState finalState);
        protected abstract void Move(int cellNum);

        public void PlayerMove(int cellNum)
        {
            Cell selectedCell = cellList[cellNum];
            if (gameState != GameState.InProgress)
                throw new GameNotInProgressException(gameState);
            else if (selectedCell.CellState != CellState.Empty)
                throw new CellNotEmptyException(selectedCell.CellLines[0], (byte)(selectedCell.CellLines[1] - 3));
            else
                Move(cellNum);
        }

        public void ComputerMove()
        {
            if (gameState == GameState.InProgress)
            {
                Random rand = new Random();
                IEnumerable<Cell> availableCells = cellList.Where(c => c.CellState == CellState.Empty);
                IEnumerable<Cell> importantCells = availableCells.Where(c => CheckImportantCell(c));
                if (importantCells.Count() > 0)
                    Move(cellList.IndexOf(importantCells.ElementAt(rand.Next(0, importantCells.Count()))));
                else
                    Move(cellList.IndexOf(availableCells.ElementAt(rand.Next(0, availableCells.Count()))));
            }
        }

        private bool CheckImportantCell(Cell cell)
        {
            foreach (byte line in cell.CellLines)
                if (Math.Abs(lineStates[line]) == 2)
                    return true;
            return false;
        }
    }

    enum CellState
    {
        Empty,
        Tic,
        Tac
    }

    enum GameState
    {
        NotInProgress,
        InProgress,
        TicWon,
        TacWon,
        Draw
    }
}
