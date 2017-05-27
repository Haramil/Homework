using TTTStatisticsLibrary;

namespace TicTacToe
{
    /// <summary>
    /// Интерфейс игровой логики
    /// </summary>
    interface IGameLogic
    {
        /// <summary>
        /// Запускает игру
        /// </summary>
        /// <param name="isSinglePlayer">Указывает, с кем играет игрок - с компьютером или с другим игроком</param>
        /// <param name="isPlayerSecond">Указывает, кто ходит вторым - человек или компьютер</param>
        void StartGame(bool isSinglePlayer, bool isPlayerSecond);

        /// <summary>
        /// Останавливает игру
        /// </summary>
        /// <param name="finalState">Итоговое состояние игры</param>
        void StopGame(GameState finalState);

        /// <summary>
        /// Осуществляет ход игрока
        /// </summary>
        /// <param name="cellNum">Номер ячейки, в которую сходил игрок</param>
        void PlayerMove(int cellNum);

        /// <summary>
        /// Осуществляет ход компьютера
        /// </summary>
        void ComputerMove();
    }
}
