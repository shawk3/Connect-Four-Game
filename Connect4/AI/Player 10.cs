using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.AI
{
    public class Player_10 : Player
    {
        new public int makeMove(Board b)
        {

            if (checkForWin(b, b.Red))
                return move;
            if (checkForWin(b, b.Blue))
                return move;
            if (checkForTrap(b, b.Red))
                return move;
            if (checkForTrap(b, b.Blue))
                return move;

            findBestMove(b);

            return move;
        }

        new public void findBestMove(Board b)
        {
            int[] spots = new int[7];



            for (int c = 0; c < 7; c++)
            {
                try
                {
                    int row = b.Available.First(x => x.Item2 == c).Item2;
                    spots[c] = count_ddl(b, new Tuple<int, int>(row, c))
                             + count_ddr(b, new Tuple<int, int>(row, c))
                             + count_h(b, new Tuple<int, int>(row, c))
                             + count_v(b, new Tuple<int, int>(row, c));

                }
                catch (Exception e)
                {
                    ;
                }
            }
            int col = getMaxIndex(spots);

            move = col;

            double maxScore = .8;
            foreach (Tuple<int, int> s in b.Available)
            {
                Board a = new Board(b);
                a.addRed(s.Item2);
                double score = lookAhead(a, 4);
                if (score > maxScore)
                {
                    maxScore = score;
                    move = s.Item2;
                }
            }


        }

        public double lookAhead(Board b, int turnsToGo)
        {
            if (turnsToGo == 0)
                return 0;

            double score = 0;
            // it is the enemies turn
            if(turnsToGo % 2 == 0)
            {
                if (checkForWin(b, b.Blue))
                    return -1;
                
                foreach(Tuple<int,int> i in b.Available)
                {
                    Board a = new Board(b);
                    a.addBlue(i.Item2);
                    score += lookAhead(a, turnsToGo - 1);
                }
            }
            // it is my turn
            if(turnsToGo % 2 == 1)
            {
                if (checkForWin(b, b.Red))
                    return 1;
                
                foreach (Tuple<int, int> i in b.Available)
                {
                    Board a = new Board(b);
                    a.addRed(i.Item2);
                    double s = lookAhead(a, turnsToGo - 1) / 7;
                    if (s >= 0)
                        score += s;
                    else
                        return 0;
                }
            }

            return score;
        }

    }
}
