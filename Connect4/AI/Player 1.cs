using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.AI
{
    public class Player_1 : Player
    {
        new public int makeMove(Board b)
        {
            if (checkForWin(b, b.Red))
                return move;
            if (checkForWin(b, b.Blue))
                return move;

            findBestMove(b);

            return move;
        }
    }
}
