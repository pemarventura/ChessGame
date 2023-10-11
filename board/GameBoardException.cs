using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    public class GameBoardException : Exception 
    {
        public GameBoardException(string message) : base(message) 
        { 
        }
    }
}
