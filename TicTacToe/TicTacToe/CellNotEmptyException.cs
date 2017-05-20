using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
