using System;
using TTTStatisticsLibrary;

namespace TicTacToe.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает, когда игрок хочет сходить, в то время как игра закончена или остановлена
    /// </summary>
    public class GameNotInProgressException : Exception
    {
        /// <summary>
        /// Указывает текущее состояние игры
        /// </summary>
        public GameState CurrentState { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса GameNotInProgressException
        /// </summary>
        public GameNotInProgressException(GameState currentState)
        {
            CurrentState = currentState;
        }
    }
}
