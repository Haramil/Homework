using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface IGameLogic
    {
        void StartGame();
        void StopGame(GameState finalState);
        void Move(int cellNum);
        void PlayerMove(int cellNum);
        void ComputerMove();
    }
}
