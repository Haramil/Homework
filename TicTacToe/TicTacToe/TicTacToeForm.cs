using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        TicTacToeFormLogic logic;

        public TicTacToeForm()
        {
            InitializeComponent();
            logic = new TicTacToeFormLogic(new HashSet<Button>(gameFieldGroupBox.Controls.Cast<Button>()), 
                currentSideLabel, resultLabel);
        }

        private void singlePlayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectTicTacGroupBox.Enabled = singlePlayerRadioButton.Checked;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            logic.StartGame();
            if (singlePlayerRadioButton.Checked && tacRadioButton.Checked)
                logic.ComputerMove();
            ErrorClear();
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            try
            {
                logic.PlayerMove((sender as Button).TabIndex);
                if (singlePlayerRadioButton.Checked)
                    logic.ComputerMove();
                ErrorClear();
            }
            catch (GameNotInProgressException ex)
            {
                errorLabel.Text = string.Format("Игра не началась. Текущее состояние - {0}", ex.CurrentState.ToString());
            }
            catch (CellNotEmptyException ex)
            {
                errorLabel.Text = string.Format("Ячейка [{0}][{1}] занята", ex.HorizontalNum + 1, ex.VerticalNum + 1);
                (sender as Button).FlatAppearance.BorderColor = Color.Red;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            logic.StopGame(GameState.NotInProgress);
            ErrorClear();
        }

        private void ErrorClear()
        {
            errorLabel.Text = string.Empty;
            foreach (Button cell in gameFieldGroupBox.Controls)
                cell.FlatAppearance.BorderColor = Color.Black;
        }
    }
}
