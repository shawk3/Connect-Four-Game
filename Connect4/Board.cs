using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Board
    {
        //0 = empty
        //1 = available
        //66 = blue
        //82 = red 

        public int[,] board;
        int height = 6;
        int width = 7;

        //item1 = row, item2 = column
        public List<Tuple<int, int>> Blue;   
        public List<Tuple<int, int>> Red;    
        public List<Tuple<int, int>> Available;

        public Board()
        {
            board = new int[height, width];
            Available = new List<Tuple<int, int>>();
            Blue = new List<Tuple<int, int>>();
            Red = new List<Tuple<int, int>>();

            for (int i = 0; i < width; i++)
                addAvailable(0, i);


        }

        public Board(Board b)
        {
            board = new int[height, width];
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    board[j,i] = b.board[j,i];
                }
            }
            Available = new List<Tuple<int, int>>();
            Blue = new List<Tuple<int, int>>();
            Red = new List<Tuple<int, int>>();
            foreach (Tuple<int,int> a in b.Available)
            {
                Available.Add(new Tuple<int, int>(a.Item1, a.Item2));
            }
            foreach (Tuple<int, int> a in b.Blue)
            {
                Blue.Add(new Tuple<int, int>(a.Item1, a.Item2));
            }
            foreach (Tuple<int, int> a in b.Red)
            {
                Red.Add(new Tuple<int, int>(a.Item1, a.Item2));
            }
        }


        private void addAvailable(int row, int column)
        {
            Available.Add(new Tuple<int, int>(row, column));
            board[row, column] = 1;
        }

        public int addBlue(int column)
        {
            //Exception if column is full
            try
            {
                Tuple<int, int> spot = Available.First(x => x.Item2 == column);
                Available.Remove(spot);
                Blue.Add(spot);
                if (spot.Item1 < height - 1)
                    addAvailable(spot.Item1 + 1, spot.Item2);
                board[spot.Item1, column] = 66;
                return spot.Item1;

            }
            catch(Exception e)
            {
                return -1;
            }

        }

        public int addRed(int column)
        {
            //Exception if column is full
            try
            {
                Tuple<int, int> spot = Available.First(x => x.Item2 == column);
                Available.Remove(spot);
                Red.Add(spot);
                if (spot.Item1 < height - 1)
                    addAvailable(spot.Item1 + 1, spot.Item2);
                board[spot.Item1, column] = 82;
                return spot.Item1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }


    }
}
