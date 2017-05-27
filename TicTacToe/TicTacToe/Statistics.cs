using System;

namespace TicTacToe
{
    public class Statistics
    {
        public DateTime GameDate { get; set; }
        public Player TicPlayer { get; set; }
        public Player TacPlayer { get; set; }
        public GameState GameResult { get; set; }
        public int MovesCount { get; set; }
    }

    public enum Player
    {
        Human,
        Computer
    }
}
