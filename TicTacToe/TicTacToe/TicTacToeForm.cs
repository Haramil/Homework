using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        TicTacToeFormLogic logic;

        public TicTacToeForm()
        {
            InitializeComponent();
            // Создаем экземпляр класса TicTacToeFormLogic,
            // передаем в него множество с кнопками и лейблы для вывода информации
            logic = new TicTacToeFormLogic(new HashSet<Button>(gameFieldGroupBox.Controls.Cast<Button>()), 
                currentSideLabel, resultLabel);
        }

        private void singlePlayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Если выбрана одиночная игра, то пользователь может выбрать, за кого играть
            selectTicTacGroupBox.Enabled = singlePlayerRadioButton.Checked;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Запуск игры
            logic.StartGame();
            // Если выбрана однопользовательская игра, и игрок за нолики, то осуществляется первый ход компьютера
            if (singlePlayerRadioButton.Checked && tacRadioButton.Checked)
                logic.ComputerMove();
            ErrorClear();
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Ход игрока
                logic.PlayerMove((sender as Button).TabIndex);
                if (singlePlayerRadioButton.Checked)
                    // Ход компьютера
                    logic.ComputerMove();
                ErrorClear();
            }
            catch (GameNotInProgressException ex) // Обрабатываем исключение GameNotInProgressException
            {
                errorLabel.Text = string.Format("Игра остановлена. Текущее состояние - {0}", ex.CurrentState.ToString());
            }
            catch (CellNotEmptyException ex) // Обрабатываем исключение CellNotEmptyException
            {
                errorLabel.Text = string.Format("Ячейка [{0}][{1}] занята", ex.HorizontalNum + 1, ex.VerticalNum + 1);
                (sender as Button).FlatAppearance.BorderColor = Color.Red;
            }
            catch (Exception ex) // Обрабатываем остальные исключения
            {
                errorLabel.Text = ex.Message;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Остановка игры
            logic.StopGame(GameState.NotInProgress);
            ErrorClear();
        }

        /// <summary>
        /// Очистка сообщений об ошибках
        /// </summary>
        private void ErrorClear()
        {
            errorLabel.Text = string.Empty;
            foreach (Button cell in gameFieldGroupBox.Controls)
                cell.FlatAppearance.BorderColor = Color.Black;
        }
    }
}
