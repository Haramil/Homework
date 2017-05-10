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
        Bitmap emptyCellImage = Properties.Resources.Empty; // Изображение пустой клетки
        Dictionary<string, Bitmap> cellImages = new Dictionary<string, Bitmap>
        {
            { "X", Properties.Resources.X },
            { "O", Properties.Resources.O }
        }; // Изображения крестика и нолика

        private int[] sumLines; // Массив для проверки линий поля
        private string currentSide; // Текущая сторона (кто сейчас ходит - крестики или нолики)
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
        private int emptyCells; // Счётчик пустых клеток - нужен для проверки ничьи

        public TicTacToeForm()
        {
            InitializeComponent();
            // Записываем, каким линиям принадлежит клетка поля
            // 0 - верхняя горизонталь
            // 1 - средняя горизонталь
            // 2 - нижняя горизонталь
            // 3 - левая вертикаль
            // 4 - средняя вертикаль
            // 5 - правая вертикаль
            // 6 - главная диагональ
            // 7 - побочная диагональ
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
            // Отключение выбора стороны при выборе одиночной игры
            selectTicTacGroupBox.Enabled = singlePlayerRadioButton.Checked;
        }

        private void startButton_Click(object sender, EventArgs e) // Кнопка старта
        {
            foreach (Button cellButton in gameFieldGroupBox.Controls) // Очистка поля
                cellButton.BackgroundImage = emptyCellImage;
            gameFieldGroupBox.Enabled = true;
            resultLabel.Text = string.Empty; // Очистка сообщения результата
            sumLines = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }; // Обнуляем массив линий поля
            CurrentSide = "X"; // Первыми ходят крестики
            emptyCells = 9;
            if (singlePlayerRadioButton.Checked && tacRadioButton.Checked)
                ComputerMove(); // Ход компьютера, если игрок - за нолики
        }

        private void cellButton_Click(object sender, EventArgs e) // Ход игрока
        {
            if ((sender as Button).BackgroundImage == emptyCellImage) // Проверка на то, что клетка пуста
            {
                if (MakeMove(sender as Button) && singlePlayerRadioButton.Checked)
                    ComputerMove(); // Ход компьютера, если игра не окончена
            }
        }

        private bool MakeMove(Button cellButton) // Обработка хода
        {
            emptyCells--;
            cellButton.BackgroundImage = cellImages[CurrentSide]; // Рисуем крестик или нолик на выбранной клетке
            foreach (int line in cellButton.Tag as int[]) // Проверка линий
            {
                sumLines[line] += (CurrentSide == "X") ? 1 : -1;
                // Изменяем счётчик линии
                // +1, если в клетке - крестик
                // -1, если в клетке - нолик
                if (sumLines[line] == 3) // Линия заполнена крестиками
                    EndGame("победил игрок за крестики");
                else if (sumLines[line] == -3) // Линия заполнена ноликами
                    EndGame("победил игрок за нолики");
                else continue;
                return false;
            }
            if (emptyCells == 0) // Пустых клеток не осталось
            {
                EndGame("ничья");
                return false;
            }
            CurrentSide = (CurrentSide == "X") ? "O" : "X"; // Смена текущей стороны
            return true;
        }

        private void EndGame(string message) // Окончание игры
        {
            resultLabel.Text = message; // Вывод сообщения результата
            gameFieldGroupBox.Enabled = false;
            currentSideLabel.Text = string.Empty;
        }

        private void ComputerMove() // Ход компьютера
        {
            Random rand = new Random();
            IEnumerable<Button> availableCells = gameFieldGroupBox.Controls.Cast<Button>().Where(b => b.BackgroundImage == emptyCellImage);
            IEnumerable<Button> importantCells = availableCells.Where(b => CheckImportantCell(b));
            if (importantCells.Count() > 0)
                MakeMove(importantCells.ElementAt(rand.Next(0, importantCells.Count())));
            else
                MakeMove(availableCells.ElementAt(rand.Next(0, availableCells.Count())));
        }

        // Проверка важных клеток поля, т.е. тех клеток, чьи линии почти заполнены
        private bool CheckImportantCell(Button cell)
        {
            foreach (int line in (cell.Tag as int[]))
                if (Math.Abs(sumLines[line]) == 2)
                    return true;
            return false;
        }
    }
}
