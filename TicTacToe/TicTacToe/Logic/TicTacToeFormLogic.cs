using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TicTacToe.Interfaces;
using TTTStatisticsLibrary;

namespace TicTacToe.Logic
{
    /// <summary>
    /// Представляет логику игры "Крестики-нолики" для формы TicTacToeForm
    /// </summary>
    public class TicTacToeFormLogic : TicTacToeLogic
    {
        /// <summary>
        /// Объект класса Label, куда выводится информация о том, кто сейчас ходит
        /// </summary>
        private Label sideLabel;

        /// <summary>
        /// Объект класса Label, куда выводится информация о результате игры
        /// </summary>
        private Label resultLabel;

        /// <summary>
        /// Объект класса TextBox, в котором записан URI сервера со статистикой
        /// </summary>
        private TextBox addressTextBox;

        /// <summary>
        /// Хэшированное множество объектов класса Button, представляющих ячейки игрового поля
        /// </summary>
        private HashSet<Button> cellButtonSet;

        /// <summary>
        /// Изображение пустой ячейки
        /// </summary>
        private Image emptyImage;

        /// <summary>
        /// Изображение крестика
        /// </summary>
        private Image ticImage;

        /// <summary>
        /// Изображение нолика
        /// </summary>
        private Image tacImage;

        /// <summary>
        /// Служит для отправки статистики на сервер
        /// </summary>
        private IStatisticsWrapper statisticsWrapper;

        /// <summary>
        /// Указывает состояние игры
        /// </summary>
        public GameState GameState
        {
            get
            {
                return gameState;
            }
            private set // В resultLabel выводится состояние игры
            {
                switch (value)
                {
                    case GameState.NotInProgress:
                        resultLabel.Text = "остановлено";
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

        /// <summary>
        /// Указывает текущую сторону
        /// </summary>
        public CellState CurrentSideState
        {
            get
            {
                return currentSideState;
            }
            private set // В sideLabel выводится, кто сейчас ходит
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

        /// <summary>
        /// Представляет список ячеек поля
        /// </summary>
        public List<Cell> CellList
        {
            get
            {
                return new List<Cell>(cellList);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса TicTacToeFormLogic
        /// </summary>
        /// <param name="cellButtonSet">Хэшированное множество объектов класса Button, представляющих ячейки игрового поля</param>
        /// <param name="sideLabel">Объект класса Label, куда будет выводиться информация о том, кто сейчас ходит</param>
        /// <param name="resultLabel">Объект класса Label, куда будет выводиться информация о результате игры</param>
        /// <param name="addressTextBox">Объект класса TextBox, в котором записан URI сервера со статистикой</param>
        /// <param name="ticImage">Изображение крестика</param>
        /// <param name="tacImage">Изображение нолика</param>
        /// <param name="emptyImage">Изображение пустой ячейки</param>
        /// <param name="statisticsWrapper">Служит для отправки статистики на сервер</param>
        public TicTacToeFormLogic(HashSet<Button> cellButtonSet, Label sideLabel, Label resultLabel,
            TextBox addressTextBox, Image ticImage, Image tacImage, Image emptyImage, IStatisticsWrapper statisticsWrapper) : base()
        {   
            this.cellButtonSet = cellButtonSet;
            this.sideLabel = sideLabel;
            this.resultLabel = resultLabel;
            this.addressTextBox = addressTextBox;
            this.ticImage = ticImage;
            this.tacImage = tacImage;
            this.emptyImage = emptyImage;
            this.statisticsWrapper = statisticsWrapper;
        }

        /// <summary>
        /// Запускает игру
        /// </summary>
        /// <param name="isSinglePlayer">Указывает, с кем играет игрок - с компьютером или с другим игроком</param>
        /// <param name="isPlayerSecond">Указывает, кто ходит вторым - человек или компьютер</param>
        public override void StartGame(bool isSinglePlayer, bool isPlayerSecond)
        {
            lineStates = new sbyte[8]; // Очищаем состояния линий поля
            for (int i = 0; i < cellList.Count; i++) // Очищаем все ячейки поля
            {
                cellList[i].CellState = CellState.Empty;
                cellButtonSet.FirstOrDefault(b => b.TabIndex == i).BackgroundImage = emptyImage;
            }
            CurrentSideState = CellState.Tic; // Первыми ходят крестики
            GameState = GameState.InProgress; // Состояние "в процессе"
            this.isSinglePlayer = isSinglePlayer;
            this.isPlayerSecond = isPlayerSecond;
            // Если выбрана однопользовательская игра, и игрок за нолики, то осуществляется первый ход компьютера
            if (isSinglePlayer && isPlayerSecond)
                ComputerMove();
        }

        /// <summary>
        /// Осуществляет обработку хода
        /// </summary>
        /// <param name="cellNum">Номер ячейки, в которую сходили</param>
        protected override void Move(int cellNum)
        {
            Cell selectedCell = cellList[cellNum];
            Button selectedButton = cellButtonSet.FirstOrDefault(b => b.TabIndex == cellNum);
            selectedCell.CellState = currentSideState; // Устанавливаем состояние выбранной ячейки
            switch (currentSideState)
            // Меняем состояния линий поля, которым принадлежит ячейка
            // Проверяем, есть ли из них линия, которая полностью заполнена либо крестиками, либо ноликами
            // Если есть - заканчиваем игру (победа крестиков или ноликов)
            {
                case CellState.Tic:
                    selectedButton.BackgroundImage = ticImage;
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
                    selectedButton.BackgroundImage = tacImage;
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
            // Если все ячейки заполнены, то заканчиваем игру (ничья)
            if (!cellList.Any(c => c.CellState == CellState.Empty))
            {
                StopGame(GameState.Draw);
                return;
            }
            // Меняем текущую сторону
            CurrentSideState = currentSideState == CellState.Tic ? CellState.Tac : CellState.Tic;
        }

        /// <summary>
        /// Останавливает игру
        /// </summary>
        /// <param name="finalState">Итоговое состояние игры</param>
        public override void StopGame(GameState finalState)
        {
            GameState = finalState;
            CurrentSideState = CellState.Empty;
            switch (finalState)
            {
                case GameState.Draw:
                case GameState.TicWon:
                case GameState.TacWon:
                    statisticsWrapper.SendGameResult(addressTextBox.Text, new Statistic
                    {
                        GameDate = DateTime.Now,
                        GameResult = finalState,
                        MovesCount = cellList.Count(c => c.CellState != CellState.Empty),
                        TicPlayer = isSinglePlayer && isPlayerSecond ? Player.Computer : Player.Human,
                        TacPlayer = isSinglePlayer && !isPlayerSecond ? Player.Computer : Player.Human
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
