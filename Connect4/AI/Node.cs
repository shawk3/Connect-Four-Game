using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.AI
{
    public class Node
    {
        public int myddl;
        public int myddr;
        public int myv;
        public int myh;
        public int yourddl;
        public int yourddr;
        public int yourv;
        public int yourh;
        int bias = 1;

        public int row;
        public int column;

        double score;

        public Node(Board b, Tuple<int, int> n)
        {
            myddl = count_ddl(b, n, true);
            myddr = count_ddr(b, n, true);
            myh = count_h(b, n, true);
            myv = count_v(b, n, true);
            yourddl = count_ddl(b, n, false);
            yourddr = count_ddr(b, n, false);
            yourh = count_h(b, n, false);
            yourv = count_v(b, n, false);

            row = n.Item1;
            column = n.Item2;
        }

        public double calculateScore(double[] weights)
        {
            score = myddl * weights[0] + myddr * weights[1]
                + myv * weights[2] + myh * weights[3]
                + yourddl * weights[4] + yourddr * weights[5]
                + yourv * weights[6] + yourh * weights[7]
                + bias * weights[8];

            return score;
        }


        public int count_ddl(Board b, Tuple<int, int> n, bool mine)
        {
            List<Tuple<int, int>> color;
            List<Tuple<int, int>> bColor;
            if (mine)
            {
                color = b.Blue;
                bColor = b.Red;
            }
            else
            {
                color = b.Red;
                bColor = b.Blue;
            }
            int sum = 0;
            int value = 0;
            int colorValue = 1;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 - i >= 0 && n.Item2 - i >= 0)
                {
                    if (bColor.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 - i)))
                        break;
                    else if (color.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 - i)))
                    {
                        sum++;
                        colorValue *= 2;
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
                    if (bColor.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                        break;
                    else if (color.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                    {
                        sum++;
                        colorValue *= 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value + colorValue;
            return 0;

        }

        public int count_ddr(Board b, Tuple<int, int> n, bool mine)
        {
            List<Tuple<int, int>> color;
            List<Tuple<int, int>> bColor;
            if (mine)
            {
                color = b.Blue;
                bColor = b.Red;
            }
            else
            {
                color = b.Red;
                bColor = b.Blue;
            }
            int sum = 0;
            int value = 0;
            int colorValue = 1;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 - i >= 0 && n.Item2 + i < 7)
                {
                    if (bColor.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 + i)))
                        break;
                    else if (color.Contains(new Tuple<int, int>(n.Item1 - i, n.Item2 + i)))
                    {
                        sum++;
                        colorValue *= 2;
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
                    if (bColor.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 - i)))
                        break;
                    else if (color.Contains(new Tuple<int, int>(n.Item1 + i, n.Item2 + i)))
                    {
                        sum++;
                        colorValue *= 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value + colorValue;
            return 0;

        }

        public int count_h(Board b, Tuple<int, int> n, bool mine)
        {
            List<Tuple<int, int>> color;
            List<Tuple<int, int>> bColor;
            if (mine)
            {
                color = b.Blue;
                bColor = b.Red;
            }
            else
            {
                color = b.Red;
                bColor = b.Blue;
            }
            int sum = 0;
            int value = 0;
            int colorValue = 1;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item2 + i < 7)
                {
                    if (bColor.Contains(new Tuple<int, int>(n.Item1, n.Item2 + i)))
                        break;
                    else if (color.Contains(new Tuple<int, int>(n.Item1, n.Item2 + i)))
                    {
                        sum++;
                        colorValue *= 2;
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
                    if (bColor.Contains(new Tuple<int, int>(n.Item1, n.Item2 - i)))
                        break;
                    else if (color.Contains(new Tuple<int, int>(n.Item1, n.Item2 - i)))
                    {
                        sum++;
                        colorValue *= 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value + colorValue;
            return 0;
        }
        public int count_v(Board b, Tuple<int, int> n, bool mine)
        {
            List<Tuple<int, int>> color;
            List<Tuple<int, int>> bColor;
            if (mine)
            {
                color = b.Blue;
                bColor = b.Red;
            }
            else
            {
                color = b.Red;
                bColor = b.Blue;
            }
            int sum = 0;
            int value = 0;
            int colorValue = 1;
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 + i < 6)
                {
                    sum++;
                    value++;
                }
            }
            for (int i = 1; i < 4; i++)
            {
                if (n.Item1 - i >= 0)
                {
                    if (bColor.Contains(new Tuple<int, int>(n.Item1 - 1, n.Item2)))
                        break;
                    else if (color.Contains(new Tuple<int, int>(n.Item1 - 1, n.Item2)))
                    {
                        sum++;
                        colorValue *= 2;
                    }
                    else
                    {
                        sum++;
                        value++;
                    }
                }
            }
            if (sum >= 3)
                return value + colorValue;
            return 0;

        }
    }
}
