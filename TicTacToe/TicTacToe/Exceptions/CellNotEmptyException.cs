﻿using System;

namespace TicTacToe.Exceptions
{
    /// <summary>
    /// Исключение, которое возникает, когда игрок хочет сходить в непустую ячейку
    /// </summary>
    public class CellNotEmptyException : Exception
    {
        /// <summary>
        /// Указывает, какой горизонтали принадлежит ячейка
        /// </summary>
        public byte HorizontalNum { get; set; }

        /// <summary>
        /// Указывает, какой вертикали принадлежит ячейка
        /// </summary>
        public byte VerticalNum { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса CellNotEmptyException
        /// </summary>
        public CellNotEmptyException(byte horizontalNum, byte verticalNum) 
        {
            HorizontalNum = horizontalNum;
            VerticalNum = verticalNum;
        }
    }
}
