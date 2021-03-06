﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace TTTStatisticsLibrary
{
    /// <summary>
    /// Статистика сыгранной игры
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// Дата сыгранной игры
        /// </summary>
        [Key]
        public DateTime GameDate { get; set; }

        /// <summary>
        /// Кто играл за крестики
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Player TicPlayer { get; set; }

        /// <summary>
        /// Кто играл за нолики
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Player TacPlayer { get; set; }

        /// <summary>
        /// Результат игры
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GameState GameResult { get; set; }

        /// <summary>
        /// Число ходов, сделанных в сыгранной игре
        /// </summary>
        public int MovesCount { get; set; }
    }

    /// <summary>
    /// Кто играет за определённую сторону
    /// </summary>
    public enum Player
    {
        /// <summary>
        /// Человек
        /// </summary>
        Human,

        /// <summary>
        /// Компьютер
        /// </summary>
        Computer
    }

    /// <summary>
    /// Возможные состояния игры
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Игра остановлена
        /// </summary>
        NotInProgress,

        /// <summary>
        /// Игра в процессе
        /// </summary>
        InProgress,

        /// <summary>
        /// Победили крестики
        /// </summary>
        TicWon,

        /// <summary>
        /// Победили нолики
        /// </summary>
        TacWon,

        /// <summary>
        /// Ничья
        /// </summary>
        Draw
    }
}
