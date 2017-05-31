using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TTTStatisticsLibrary;

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
                currentSideLabel, resultLabel, uriTextBox);
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
                logic.PlayerMove((sender as Button).TabIndex);
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
                List<Statistic> statisticsList = StatisticsWrapper.GetStatistics(uriTextBox.Text);
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
