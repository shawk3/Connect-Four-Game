using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.AI
{
    public class Player_Fred : Player
    {

        String[] listLines;
        double[] weights;
        List<Node> nodes;
        string fileName;

        public Player_Fred(bool first)
        {
            if (first)
            {
                fileName = "C:\\Users\\Kyle\\Documents\\Visual Studio 2015\\Projects\\Connect4\\Connect4\\AI\\First.txt";
            }
            else
                fileName = "C:\\Users\\Kyle\\Documents\\Visual Studio 2015\\Projects\\Connect4\\Connect4\\AI\\Second.txt";
            StreamReader myFile = new StreamReader(fileName);
            string myString = myFile.ReadToEnd();
            myString = myString.Trim('\n');
            myFile.Close();

            listLines = myString.Split('\n');
            weights = new double[listLines.Length];
            for(int i = 0; i < listLines.Length; i++)
            {
                //listLines[i].Trim('\r');
                weights[i] = Double.Parse(listLines[i]);
            }

            nodes = new List<Node>();

        }

        internal void Lost(int[] difference)
        {
            for(int i = 0; i < difference.Length; i++)
            {
                weights[i] = weights[i] - (difference[i] * weights[i] * .01);
            }
            gameOver();
        }

        internal void Won(int[] difference)
        {
            for (int i = 0; i < difference.Length; i++)
            {
                weights[i] = weights[i] + (difference[i] * weights[i] * .01);
            }
            gameOver();
        }

        private void gameOver()
        {
            string s = "";
            StreamWriter myFile = new StreamWriter(fileName);

            for (int i = 0; i < weights.Length; i++)
            {
                myFile.WriteLine(weights[i]);
            }
            myFile.Close();

        }

        new public int makeMove(Board b)
        {
            return NeuralNet(b);

        }

        private int NeuralNet(Board b)
        {
            double maxScore = -1;
            Node keepNode = null;
            foreach(Tuple<int,int> n in b.Available)
            {
                Node node = new Node(b, n);
                double score = node.calculateScore(weights);
                if(score > maxScore || maxScore < 0)
                {
                    maxScore = score;
                    keepNode = node;
                }

            }
            nodes.Add(keepNode);

            if (keepNode == null)
                return -1;
            return keepNode.column;
        }

        public int[] addScores()
        {
            int[] scores = new int[8];
            foreach(Node n in nodes)
            {
                scores[0] += n.myddl;
                scores[1] += n.myddr;
                scores[2] += n.myv;
                scores[3] += n.myh;
                scores[4] += n.yourddl;
                scores[5] += n.yourddr;
                scores[6] += n.yourv;
                scores[7] += n.yourh;

            }
            return scores;
        }
    }
}
