using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
