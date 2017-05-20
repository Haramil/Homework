using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    class TicTacToeFormLogic : TicTacToeLogic
    {
        private Label sideLabel;
        private Label resultLabel;
        private HashSet<Button> cellButtonSet;

        private Image Empty = Properties.Resources.Empty;
        private Image X = Properties.Resources.X;
        private Image O = Properties.Resources.O;

        private GameState GameState
        {
            get
            {
                return gameState;
            }
            set
            {
                switch (value)
                {
                    case GameState.NotInProgress:
                        resultLabel.Text = "не в процессе";
                        break;
                    case GameState.InProgress:
                        resultLabel.Text = "в процессе";
                        break;
                    case GameState.TicWon:
                        resultLabel.Text = "победили крестики";
                        break;
                    case GameState.TacWon:
                        resultLabel.Text = "победили нолики";
                        break;
                    case GameState.Draw:
                        resultLabel.Text = "ничья";
                        break;
                }
                gameState = value;
            }
        }

        private CellState CurrentSideState
        {
            get
            {
                return currentSideState;
            }
            set
            {
                switch (value)
                {
                    case CellState.Empty:
                        sideLabel.Text = string.Empty;
                        break;
                    case CellState.Tic:
                        sideLabel.Text = "крестики";
                        break;
                    case CellState.Tac:
                        sideLabel.Text = "нолики";
                        break;
                }
                currentSideState = value;
            }
        }

        public TicTacToeFormLogic(HashSet<Button> cellButtonSet, Label sideLabel, Label resultLabel) : base()
        {
            this.cellButtonSet = cellButtonSet;
            this.sideLabel = sideLabel;
            this.resultLabel = resultLabel;
        }

        public override void StartGame()
        {
            lineStates = new sbyte[8];
            for (int i = 0; i < cellList.Count; i++)
            {
                cellList[i].CellState = CellState.Empty;
                cellButtonSet.FirstOrDefault(b => b.TabIndex == i).BackgroundImage = Empty;
            }
            CurrentSideState = CellState.Tic;
            GameState = GameState.InProgress;
        }

        protected override void Move(int cellNum)
        {
            Cell selectedCell = cellList[cellNum];
            Button selectedButton = cellButtonSet.FirstOrDefault(b => b.TabIndex == cellNum);
            selectedCell.CellState = currentSideState;
            switch (currentSideState)
            {
                case CellState.Tic:
                    selectedButton.BackgroundImage = X;
                    foreach (byte line in selectedCell.CellLines)
                    {
                        lineStates[line]++;
                        if (Math.Abs(lineStates[line]) == 3)
                        {
                            StopGame(GameState.TicWon);
                            return;
                        }
                    }
                    break;
                case CellState.Tac:
                    selectedButton.BackgroundImage = O;
                    foreach (byte line in selectedCell.CellLines)
                    {
                        lineStates[line]--;
                        if (Math.Abs(lineStates[line]) == 3)
                        {
                            StopGame(GameState.TacWon);
                            return;
                        }
                    }
                    break;
            }
            if (cellList.Count(c => c.CellState == CellState.Empty) == 0)
            {
                StopGame(GameState.Draw);
                return;
            }
            CurrentSideState = currentSideState == CellState.Tic ? CellState.Tac : CellState.Tic;
        }

        public override void StopGame(GameState finalState)
        {
            GameState = finalState;
            CurrentSideState = CellState.Empty;
        }
    }
}
