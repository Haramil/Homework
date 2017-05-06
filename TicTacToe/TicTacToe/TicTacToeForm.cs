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
        Bitmap emptyCellImage = Properties.Resources.Empty;
        Dictionary<string, Bitmap> cellImages = new Dictionary<string, Bitmap>
        {
            { "X", Properties.Resources.X },
            { "O", Properties.Resources.O }
        };

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
                cellButton.BackgroundImage = emptyCellImage;
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
            if ((sender as Button).BackgroundImage == emptyCellImage)
            {
                if (MakeMove(sender as Button) && singlePlayerRadioButton.Checked)
                    ComputerMove();
            }
        }

        private bool MakeMove(Button cellButton)
        {
            emptyCells--;
            cellButton.BackgroundImage = cellImages[CurrentSide];
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
            IEnumerable<Button> availableCells = gameFieldGroupBox.Controls.Cast<Button>().Where(b => b.BackgroundImage == emptyCellImage);
            IEnumerable<Button> importantCells = availableCells.Where(b => CheckImportantCell(b));
            if (importantCells.Count() > 0)
                MakeMove(importantCells.ElementAt(rand.Next(0, importantCells.Count())));
            else
                MakeMove(availableCells.ElementAt(rand.Next(0, availableCells.Count())));
        }

        private bool CheckImportantCell(Button cell)
        {
            foreach (int line in (cell.Tag as int[]))
                if (Math.Abs(sumLines[line]) == 2)
                    return true;
            return false;
        }
    }
}
