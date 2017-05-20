using System;

namespace TicTacToe
{
    class CellNotEmptyException : Exception
    {
        public byte HorizontalNum { get; set; }
        public byte VerticalNum { get; set; }

        public CellNotEmptyException(byte horizontalNum, byte verticalNum) 
        {
            HorizontalNum = horizontalNum;
            VerticalNum = verticalNum;
        }
    }
}
