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
        public TicTacToeForm()
        {
            InitializeComponent();
        }

        private void singlePlayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectTicTacGroupBox.Enabled = singlePlayerRadioButton.Checked;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameFieldGroupBox.Enabled = true;
        }
    }
}
