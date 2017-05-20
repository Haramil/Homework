namespace TicTacToe
{
    interface IGameLogic
    {
        void StartGame();
        void StopGame(GameState finalState);
        void PlayerMove(int cellNum);
        void ComputerMove();
    }
}
