using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Connect4.AI;

namespace Connect4
{
    public class PlayerManager
    {
        int mode;
        bool busy;
        public Board b;
        bool play1Turn;
        Player player;

        public PlayerManager(int mode)
        {
            if(mode == 2)
                player = new Player_5();
            if (mode == 3)
                player = new Player_1();
            if (mode == 4)
                player = new Player_Fred(true);

            this.mode = mode;
            busy = false;
            play1Turn = true;
            b = new Board();
            if (mode == 5)
                playMode3();

        }

        public int ColumnClicked(int c)
        {
            if (busy)
                return -1;

            busy = true;
            switch (mode)
            {
                case 1:
                    return playMode1(c);
                case 2:
                case 3:
                case 4:
                    return playMode2(c);
                case 5:
                    return -1;
                default:
                    return playMode1(c);
            }

        }

        private int playMode2(int c)
        {
            int r = -1;
            r = b.addBlue(c);
            busy = false;
            if (r >= 0)
            {
                play1Turn = true;
                if (checkForWin(r, c))
                {
                    MessageBox.Show("You have Won!");
                    busy = true;
                }

            }
            else
                return r;

            if (!busy)
            {
                //Let the computer play
                if(mode == 2)
                    c = (player as Player_5).makeMove(b);
                if (mode == 3)
                    c = (player as Player_1).makeMove(b); 
                if (mode == 4)
                    c = (player as Player_Fred).makeMove(b);
                r = b.addRed(c);
                if (r >= 0)
                {
                    play1Turn = false;
                    if (checkForWin(r, c))
                    {
                        MessageBox.Show("You have Lost!");
                        busy = true;
                    }

                }
            }

            return r;
        }

        private int playFred(int c)
        {
            int r = -1;
            r = b.addBlue(c);
            busy = false;
            if (r >= 0)
            {
                play1Turn = true;
                if (checkForWin(r, c))
                {
                    MessageBox.Show("You have Won!");
                    busy = true;
                }

            }
            else
                return r;

            if (!busy)
            {
                //Let the computer play
                c = (player as Player_Fred).makeMove(b);
                r = b.addRed(c);
                if (r >= 0)
                {
                    play1Turn = false;
                    if (checkForWin(r, c))
                    {
                        MessageBox.Show("You have Lost!");
                        busy = true;
                    }

                }
            }

            return r;
        }

        private int playMode1(int c)
        {
            int r = -1;
            if (play1Turn)
                r = b.addBlue(c);
            else
                r = b.addRed(c);
            busy = false;

            if(r >= 0)
            {
                if (checkForWin(r, c))
                {
                    MessageBox.Show("You have Won!");
                    busy = true;
                }
                play1Turn = !play1Turn;

            }

            return r;
        }

        public void playMode3()
        {
            int c = 3;
            bool gameover = false;
            int r;
            Player_Fred fred = new Player_Fred(true);
            Player_Fred george = new Player_Fred(false);
            while (!gameover)
            {
                play1Turn = true;
                c = fred.makeMove(b);
                if (c < 0)
                {
                    tie(fred, george);
                    return; 
                }
                    
                r = b.addBlue(c);
                if (r >= 0)
                {
                    if (checkForWin(r, c))
                    {

                        Mode3GameOver(fred, george, true);
                        return;
                    }

                }
                play1Turn = false;
                c = george.makeMove(b);
                if (c < 0)
                {
                    tie(fred, george);
                    return;
                }
                r = b.addRed(c);
                if (r >= 0)
                {
                    if (checkForWin(r, c))
                    {
                        Mode3GameOver(fred, george, false);
                        return;
                    }

                }
            }
        }

        private void tie(Player_Fred fred, Player_Fred george)
        {
            int[] difference = new int[8];
            for (int i = 0; i < 4; i++)
            {
                difference[i*2] = -1;
            }


            fred.Lost(difference);

            return;
        }

        private void Mode3GameOver(Player_Fred fred, Player_Fred george, bool FredWon)
        {
            int alpha = 1;
            if (!FredWon)
                alpha = -1;
            int[] FredScores = fred.addScores();
            int[] GeorgeScores = george.addScores();
            int[] difference = new int[8];
            for(int i = 0; i < difference.Length; i++)
            {
                difference[i] = (FredScores[i] - GeorgeScores[i]) * alpha;
            }

            if (FredWon)
            {
                fred.Won(difference);
                george.Lost(difference);
            }
            else
            {
                george.Won(difference);
                fred.Lost(difference);
            }
            return;
        }
        

        private bool checkForWin(int r, int c)
        {
            List<Tuple<int, int>> claimed = new List<Tuple<int, int>>();
            if (play1Turn)
                claimed = b.Blue;
            else
                claimed = b.Red;

            foreach(Tuple<int, int> v in claimed)
            {

                if (checkWinDiagnolLeft(v.Item1, v.Item2, claimed))
                    return true;
                if (checkWinDiagnolRight(v.Item1, v.Item2, claimed))
                    return true;
                if (checkWinVertical(v.Item1, v.Item2, claimed))
                    return true;
                if (checkWinHorizontal(v.Item1, v.Item2, claimed))
                    return true;

            }

            return false;
        }

        private bool checkWinDiagnolLeft(int r, int c, List<Tuple<int, int>> claimed)
        {
            if (c < 3 || r > 2)
                return false;
            for(int i = 1; i < 4; i++)
            {
                try
                {
                    Tuple<int, int> piece = claimed.First(x => x.Item1 == (r+i) && x.Item2 == (c-i));
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkWinDiagnolRight(int r, int c, List<Tuple<int, int>> claimed)
        {
            if (c > 3 || r > 2)
                return false;
            for (int i = 1; i < 4; i++)
            {
                try
                {
                    Tuple<int, int> piece = claimed.First(x => x.Item1 == (r + i) && x.Item2 == (c + i));
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkWinVertical(int r, int c, List<Tuple<int, int>> claimed)
        {
            if (r > 2)
                return false;
            for (int i = 1; i < 4; i++)
            {
                try
                {
                    Tuple<int, int> piece = claimed.First(x => x.Item1 == (r + i) && x.Item2 == c);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkWinHorizontal(int r, int c, List<Tuple<int, int>> claimed)
        {
            if (c > 3)
                return false;
            for (int i = 1; i < 4; i++)
            {
                try
                {
                    Tuple<int, int> piece = claimed.First(x => x.Item1 == (r) && x.Item2 == (c + i));
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
