using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TicTacToe.Exceptions;
using TicTacToe.Logic;
using TicTacToe.Wrappers;
using TTTStatisticsLibrary;

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        TicTacToeFormLogic logic;
        StatisticsWrapper wrapper;

        public TicTacToeForm()
        {
            InitializeComponent();
            // Создаём экземпляр класса StatisticsWrapper
            wrapper = new StatisticsWrapper();
            // Создаем экземпляр класса TicTacToeFormLogic,
            // передаем в него словарь с кнопками, лейблы для вывода информации, изображения для ячеек и объект wrapper
            logic = new TicTacToeFormLogic(gameFieldGroupBox.Controls.Cast<Button>().ToDictionary(b => (byte)b.TabIndex, b => b), 
                currentSideLabel, resultLabel, uriTextBox, Properties.Resources.X, Properties.Resources.O, Properties.Resources.Empty, wrapper);
        }

        private void singlePlayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Если выбрана одиночная игра, то пользователь может выбрать, за кого играть
            selectTicTacGroupBox.Enabled = singlePlayerRadioButton.Checked;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Запуск игры
            logic.StartGame(singlePlayerRadioButton.Checked, tacRadioButton.Checked);
            ErrorClear();
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Ход игрока
                logic.PlayerMove((byte)(sender as Button).TabIndex);
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

        private void getStatisticsButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Запрос статистики от сервера и её отображение в DataGridView
                List<Statistic> statisticsList = wrapper.GetStatistics(uriTextBox.Text);
                statisticsDataGridView.DataSource = statisticsList;
                // Подсчёт процента побед человека
                int HumanWins = 0;
                if (statisticsList.Count > 0)
                    HumanWins = statisticsList.Count(s => (s.TicPlayer == Player.Human &&
                        s.GameResult == GameState.TicWon) ||
                        (s.TacPlayer == Player.Human &&
                        s.GameResult == GameState.TacWon)) * 100 / statisticsList.Count;
                percentLabel.Text = HumanWins + "%";
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }
    }
}
