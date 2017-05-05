using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        private int[] sumLines;
        private string currentSide;
        private string CurrentSide
        {
            get { return currentSide; }
            set
            {
                if (value == "X")
                    currentSideLabel.Text = "крестики";
                else currentSideLabel.Text = "нолики";
                currentSide = value;
            }
        }
        private int emptyCells;

        public TicTacToeForm()
        {
            InitializeComponent();
            cellButton1.Tag = new int[] { 0, 3, 6 };
            cellButton2.Tag = new int[] { 0, 4 };
            cellButton3.Tag = new int[] { 0, 5, 7 };
            cellButton4.Tag = new int[] { 1, 3 };
            cellButton5.Tag = new int[] { 1, 4, 6, 7 };
            cellButton6.Tag = new int[] { 1, 5 };
            cellButton7.Tag = new int[] { 2, 3, 7 };
            cellButton8.Tag = new int[] { 2, 4 };
            cellButton9.Tag = new int[] { 2, 5, 6 };
        }

        private void singlePlayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectTicTacGroupBox.Enabled = singlePlayerRadioButton.Checked;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            foreach (Button cellButton in gameFieldGroupBox.Controls)
                cellButton.BackgroundImage = null;
            gameFieldGroupBox.Enabled = true;
            resultLabel.Text = string.Empty;
            sumLines = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            CurrentSide = "X";
            emptyCells = 9;
            if (singlePlayerRadioButton.Checked && tacRadioButton.Checked)
                ComputerMove();
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            if ((sender as Button).BackgroundImage == null)
            {
                if (MakeMove(sender as Button) && singlePlayerRadioButton.Checked)
                    ComputerMove();
            }
        }

        private bool MakeMove(Button cellButton)
        {
            emptyCells--;
            cellButton.BackgroundImage = Properties.Resources.ResourceManager.GetObject(CurrentSide) as Bitmap;
            foreach (int line in cellButton.Tag as int[])
            {
                sumLines[line] += (CurrentSide == "X") ? 1 : -1;
                if (sumLines[line] == 3)
                    EndGame("победил игрок за крестики");
                else if (sumLines[line] == -3)
                    EndGame("победил игрок за нолики");
                else continue;
                return false;
            }
            if (emptyCells == 0)
            {
                EndGame("ничья");
                return false;
            }
            CurrentSide = (CurrentSide == "X") ? "O" : "X";
            return true;
        }

        private void EndGame(string message)
        {
            resultLabel.Text = message;
            gameFieldGroupBox.Enabled = false;
            currentSideLabel.Text = string.Empty;
        }

        private void ComputerMove()
        {
            Random rand = new Random();
            for (int i = 0; i < sumLines.Length; i++)
                if (Math.Abs(sumLines[i]) > 1)
                {
                    foreach (Button cell in gameFieldGroupBox.Controls)
                    {
                        if ((cell.Tag as IEnumerable<int>).Contains(i) && cell.BackgroundImage == null)
                        {
                            MakeMove(cell);
                            return;
                        }
                    }
                }
            while (true)
            {
                Button randButton = gameFieldGroupBox.Controls[rand.Next(0, 9)] as Button;
                if (randButton.BackgroundImage == null)
                {
                    MakeMove(randButton);
                    break;
                }
            }
        }
    }
}
