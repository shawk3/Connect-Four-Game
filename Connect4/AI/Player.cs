using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.AI
{
    public class Player
    {
        public int move;
        public int makeMove(Board b)
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

        public bool checkForWin(Board b, List<Tuple<int, int>> color)
        {


            foreach (Tuple<int, int> s in b.Available)
            {
                if (check_ddl(b, color, s))
                    return true;
                if (check_ddr(b, color, s))
                    return true;
                if (check_h(b, color, s))
                    return true;
                if (check_v(b, color, s))
                    return true;
            }
            return false;
        }

        public bool checkForTrap(Board b, List<Tuple<int, int>> color)
        {
            foreach (Tuple<int, int> s in b.Available)
            {
                if (check_ddl(b, color, s, true))
                    return true;
                if (check_ddr(b, color, s, true))
                    return true;
                if (check_h(b, color, s, true))
                    return true;
            }
            return false;
        }

        public void findBestMove(Board b)
        {
            int[] spots = new int[7];

            for (int c = 0; c < 7; c++)
            {
                try
                {
                    int row = b.Available.First(x => x.Item2 == c).Item1;
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

            bool good = false;
            int col = b.Available.ElementAt(0).Item2;
            while (!good)
            {
                Board a = new Board(b);
                col = getMaxIndex(spots);
                if(a.Available.First(x => x.Item2 == col).Item1 < 5)
                {
                    a.addRed(col);
                    if (check_ddl(b, b.Blue, a.Available.First(x => x.Item2 == col)) ||
                         check_ddr(b, b.Blue, a.Available.First(x => x.Item2 == col)) ||
                         check_h(b, b.Blue, a.Available.First(x => x.Item2 == col)))
                        spots[col] = -1;
                    else
                        good = true;
                }
                else
                    good = true;
            }

            move = col;


        }

        public int getMaxIndex(int[] list)
        {
            int max = -1;
            int index = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] >= max)
                {
                    index = i;
                    max = list[i];
                }
            }
            return index;
        }

        public int count_ddl(Board b, Tuple<int, int> n)
        {
            int sum = 0;
            int value = 0;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 - i >= 0 && n.Item2 - i >= 0)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 - i)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 - i)))
                    {
                        sum++;
                        value = value + 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 + i < 6 && n.Item2 + i < 7)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                    {
                        sum++;
                        value++; value++;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value;
            return 0;

        }

        public int count_ddr(Board b, Tuple<int, int> n)
        {
            int sum = 0;
            int value = 0;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 - i >= 0 && n.Item2 + i < 7)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 + i)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 + i)))
                    {
                        sum++;
                        value = value + 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 + i < 6 && n.Item2 - i >= 0)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 - i)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                    {
                        sum++;
                        value++; value++;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value;
            return 0;

        }

        public int count_h(Board b, Tuple<int, int> n)
        {
            int sum = 0;
            int value = 0;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item2 + i < 7)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1, n.Item2 + i)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1, n.Item2 + i)))
                    {
                        sum++;
                        value = value + 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            for (int i = 1; i < 4; i++)
            {
                if (n.Item2 - i >= 0)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1, n.Item2 - i)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1, n.Item2 - i)))
                    {
                        sum++;
                        value++; value++;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value;
            return 0;
        }
        public int count_v(Board b, Tuple<int, int> n)
        {
            int sum = 0;
            int value = 0;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 + i < 6)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1, n.Item2)))
                    {
                        sum++;
                        value = value + 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 - i >= 0)
                {
                    if (b.Blue.Contains(new Tuple<int, int>(n.Item1 - 1, n.Item2)))
                        break;
                    else if (b.Red.Contains(new Tuple<int, int>(n.Item1 - 1, n.Item2)))
                    {
                        sum++;
                        value++; value++;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value;
            return 0;

        }


        public bool check_ddl(Board b, List<Tuple<int, int>> color, Tuple<int, int> n, bool trap = false)
        {
            int sum = 0;
            int availableSum = 0;
            for (int i = 1; i < 4; i++)
            {
                if (color.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 - i)))
                    sum++;
                else if (b.Available.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 - i)))
                {
                    availableSum++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i < 4; i++)
            {
                if (color.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                    sum++;
                else if (b.Available.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                {
                    availableSum++;
                    break;
                }
                else
                    break;
            }
            if (sum >= 3)
            {
                move = n.Item2;
                return true;
            }
            if (trap && sum >= 2 && availableSum >= 2)
            {
                if (check_ddl(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)) ||
                 check_ddr(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)) ||
                 check_h(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)))
                    return false;
                else
                    return true;

            }
            return false;
        }


        public bool check_ddr(Board b, List<Tuple<int, int>> color, Tuple<int, int> n, bool trap = false)
        {
            int sum = 0;
            int availableSum = 0;
            for (int i = 1; i < 4; i++)
            {
                if (color.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 + i)))
                    sum++;
                else if (b.Available.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 + i)))
                {
                    availableSum++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i < 4; i++)
            {
                if (color.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 - i)))
                    sum++;
                else if (b.Available.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 - i)))
                {
                    availableSum++;
                    break;
                }
                else
                    break;
            }
            if (sum >= 3)
            {
                move = n.Item2;
                return true;

            }
            if (trap && sum >= 2 && availableSum >= 2)
            {
                if (check_ddl(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)) ||
                 check_ddr(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)) ||
                 check_h(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)))
                    return false;
                else
                    return true;

            }
            return false;
        }



        public bool check_h(Board b, List<Tuple<int, int>> color, Tuple<int, int> n, bool trap = false)
        {
            int sum = 0;
            int availableSum = 0;
            for (int i = 1; i < 4; i++)
            {
                if (color.Contains(new Tuple<int, int>(n.Item1, n.Item2 + i)))
                    sum++;
                else if (b.Available.Contains(new Tuple<int, int>(n.Item1, n.Item2 + i)))
                {
                    availableSum++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i < 4; i++)
            {
                if (color.Contains(new Tuple<int, int>(n.Item1, n.Item2 - i)))
                    sum++;
                else if (b.Available.Contains(new Tuple<int, int>(n.Item1, n.Item2 - i)))
                {
                    availableSum++;
                    break;
                }
                else
                    break;
            }
            if (sum >= 3)
            {
                move = n.Item2;
                return true;
            }
            if (trap && sum >= 2 && availableSum >= 2)
            {
                if (check_ddl(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)) ||
                 check_ddr(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)) ||
                 check_h(b, b.Blue, new Tuple<int, int>(n.Item1 + 1, n.Item2)))
                    return false;
                else
                {
                    move = n.Item2;
                    return true;
                }

            }
            return false;
        }

        public bool check_v(Board b, List<Tuple<int, int>> color, Tuple<int, int> n)
        {
            int sum = 0;
            for (int i = 1; i < 4; i++)
            {
                if (color.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2)))
                    sum++;
                else
                    break;
            }

            if (sum >= 3)
            {
                move = n.Item2;
                return true;

            }
            return false;
        }
    }
}
