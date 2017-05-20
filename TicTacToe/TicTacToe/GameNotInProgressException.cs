using System;

namespace TicTacToe
{
    class GameNotInProgressException : Exception
    {
        public GameState CurrentState { get; set; }

        public GameNotInProgressException(GameState currentState)
        {
            CurrentState = currentState;
        }
    }
}
