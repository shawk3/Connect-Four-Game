using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Connect4
{
    public class ViewModel:INotifyPropertyChanged
    {
        private PlayerManager playerManager;

        #region properties
        private Brush a0;
        private Brush a1;
        private Brush a2;
        private Brush a3;
        private Brush a4;
        private Brush a5;
        private Brush a6;
        private Brush b0;
        private Brush b1;
        private Brush b2;
        private Brush b3;
        private Brush b4;
        private Brush b5;
        private Brush b6;
        private Brush c0;
        private Brush c1;
        private Brush c2;
        private Brush c3;
        private Brush c4;
        private Brush c5;
        private Brush c6;
        private Brush d0;
        private Brush d1;
        private Brush d2;
        private Brush d3;
        private Brush d4;
        private Brush d5;
        private Brush d6;
        private Brush e0;
        private Brush e1;
        private Brush e2;
        private Brush e3;
        private Brush e4;
        private Brush e5;
        private Brush e6;
        private Brush f0;
        private Brush f1;
        private Brush f2;
        private Brush f3;
        private Brush f4;
        private Brush f5;
        private Brush f6;
        private Brush g0;
        private Brush g1;
        private Brush g2;
        private Brush g3;
        private Brush g4;
        private Brush g5;
        private Brush g6;

        public Brush A0 { get { return a0; } set { a0 = value; updateProperty("A0"); } }
        public Brush A1 { get { return a1; } set { a1 = value; updateProperty("A1"); } }
        public Brush A2 { get { return a2; } set { a2 = value; updateProperty("A2"); } }
        public Brush A3 { get { return a3; } set { a3 = value; updateProperty("A3"); } }
        public Brush A4 { get { return a4; } set { a4 = value; updateProperty("A4"); } }
        public Brush A5 { get { return a5; } set { a5 = value; updateProperty("A5"); } }
        public Brush A6 { get { return a6; } set { a6 = value; updateProperty("A6"); } }
        public Brush B0 { get { return b0; } set { b0 = value; updateProperty("B0"); } }
        public Brush B1 { get { return b1; } set { b1 = value; updateProperty("B1"); } }
        public Brush B2 { get { return b2; } set { b2 = value; updateProperty("B2"); } }
        public Brush B3 { get { return b3; } set { b3 = value; updateProperty("B3"); } }
        public Brush B4 { get { return b4; } set { b4 = value; updateProperty("B4"); } }
        public Brush B5 { get { return b5; } set { b5 = value; updateProperty("B5"); } }
        public Brush B6 { get { return b6; } set { b6 = value; updateProperty("B6"); } }
        public Brush C0 { get { return c0; } set { c0 = value; updateProperty("C0"); } }
        public Brush C1 { get { return c1; } set { c1 = value; updateProperty("C1"); } }
        public Brush C2 { get { return c2; } set { c2 = value; updateProperty("C2"); } }
        public Brush C3 { get { return c3; } set { c3 = value; updateProperty("C3"); } }
        public Brush C4 { get { return c4; } set { c4 = value; updateProperty("C4"); } }
        public Brush C5 { get { return c5; } set { c5 = value; updateProperty("C5"); } }
        public Brush C6 { get { return c6; } set { c6 = value; updateProperty("C6"); } }
        public Brush D0 { get { return d0; } set { d0 = value; updateProperty("D0"); } }
        public Brush D1 { get { return d1; } set { d1 = value; updateProperty("D1"); } }
        public Brush D2 { get { return d2; } set { d2 = value; updateProperty("D2"); } }
        public Brush D3 { get { return d3; } set { d3 = value; updateProperty("D3"); } }
        public Brush D4 { get { return d4; } set { d4 = value; updateProperty("D4"); } }
        public Brush D5 { get { return d5; } set { d5 = value; updateProperty("D5"); } }
        public Brush D6 { get { return d6; } set { d6 = value; updateProperty("D6"); } }
        public Brush E0 { get { return e0; } set { e0 = value; updateProperty("E0"); } }
        public Brush E1 { get { return e1; } set { e1 = value; updateProperty("E1"); } }
        public Brush E2 { get { return e2; } set { e2 = value; updateProperty("E2"); } }
        public Brush E3 { get { return e3; } set { e3 = value; updateProperty("E3"); } }
        public Brush E4 { get { return e4; } set { e4 = value; updateProperty("E4"); } }
        public Brush E5 { get { return e5; } set { e5 = value; updateProperty("E5"); } }
        public Brush E6 { get { return e6; } set { e6 = value; updateProperty("E6"); } }
        public Brush F0 { get { return f0; } set { f0 = value; updateProperty("F0"); } }
        public Brush F1 { get { return f1; } set { f1 = value; updateProperty("F1"); } }
        public Brush F2 { get { return f2; } set { f2 = value; updateProperty("F2"); } }
        public Brush F3 { get { return f3; } set { f3 = value; updateProperty("F3"); } }
        public Brush F4 { get { return f4; } set { f4 = value; updateProperty("F4"); } }
        public Brush F5 { get { return f5; } set { f5 = value; updateProperty("F5"); } }
        public Brush F6 { get { return f6; } set { f6 = value; updateProperty("F6"); } }
        public Brush G0 { get { return g0; } set { g0 = value; updateProperty("G0"); } }
        public Brush G1 { get { return g1; } set { g1 = value; updateProperty("G1"); } }
        public Brush G2 { get { return g2; } set { g2 = value; updateProperty("G2"); } }
        public Brush G3 { get { return g3; } set { g3 = value; updateProperty("G3"); } }
        public Brush G4 { get { return g4; } set { g4 = value; updateProperty("G4"); } }
        public Brush G5 { get { return g5; } set { g5 = value; updateProperty("G5"); } }
        public Brush G6 { get { return g6; } set { g6 = value; updateProperty("G6"); } }



        #endregion




        private void initializeRectangleColors()
        {
            A0 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            A1 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            A2 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            A3 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            A4 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            A5 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            A6 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            B0 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            B1 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            B2 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            B3 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            B4 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            B5 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            B6 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            C0 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            C1 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            C2 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            C3 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            C4 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            C5 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            C6 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            D0 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            D1 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            D2 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            D3 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            D4 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            D5 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            D6 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            E0 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            E1 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            E2 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            E3 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            E4 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            E5 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            E6 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            F0 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            F1 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            F2 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            F3 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            F4 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            F5 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            F6 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            G0 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            G1 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            G2 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            G3 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            G4 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            G5 = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            G6 = new SolidColorBrush(Color.FromRgb(200, 200, 200));

        }

        private void changeColor(int r, int c)
        {
            Brush color = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            if(playerManager.b.board[r,c] == 66)
                color = new SolidColorBrush(Color.FromRgb(0, 0, 200)); 
            if (playerManager.b.board[r, c] == 82)
                color = new SolidColorBrush(Color.FromRgb(200, 0, 0)); 

            


            if (c == 0)
            {
                if(r == 0)
                    A0 = color;
                if (r == 1)
                    A1 = color;
                if (r == 2)
                    A2 = color;
                if (r == 3)
                    A3 = color;
                if (r == 4)
                    A4 = color;
                if (r == 5)
                    A5 = color;
                if (r == 6)
                    A6 = color;
            }
            if (c == 1)
            {
                if (r == 0)
                    B0 = color;
                if (r == 1)
                    B1 = color;
                if (r == 2)
                    B2 = color;
                if (r == 3)
                    B3 = color;
                if (r == 4)
                    B4 = color;
                if (r == 5)
                    B5 = color;
                if (r == 6)
                    B6 = color;
            }
            if (c == 2)
            {
                if (r == 0)
                    C0 = color;
                if (r == 1)
                    C1 = color;
                if (r == 2)
                    C2 = color;
                if (r == 3)
                    C3 = color;
                if (r == 4)
                    C4 = color;
                if (r == 5)
                    C5 = color;
                if (r == 6)
                    C6 = color;
            }
            if (c == 3)
            {
                if (r == 0)
                    D0 = color;
                if (r == 1)
                    D1 = color;
                if (r == 2)
                    D2 = color;
                if (r == 3)
                    D3 = color;
                if (r == 4)
                    D4 = color;
                if (r == 5)
                    D5 = color;
                if (r == 6)
                    D6 = color;
            }
            if (c == 4)
            {
                if (r == 0)
                    E0 = color;
                if (r == 1)
                    E1 = color;
                if (r == 2)
                    E2 = color;
                if (r == 3)
                    E3 = color;
                if (r == 4)
                    E4 = color;
                if (r == 5)
                    E5 = color;
                if (r == 6)
                    E6 = color;
            }
            if (c == 5)
            {
                if (r == 0)
                    F0 = color;
                if (r == 1)
                    F1 = color;
                if (r == 2)
                    F2 = color;
                if (r == 3)
                    F3 = color;
                if (r == 4)
                    F4 = color;
                if (r == 5)
                    F5 = color;
                if (r == 6)
                    F6 = color;
            }
            if (c == 6)
            {
                if (r == 0)
                    G0 = color;
                if (r == 1)
                    G1 = color;
                if (r == 2)
                    G2 = color;
                if (r == 3)
                    G3 = color;
                if (r == 4)
                    G4 = color;
                if (r == 5)
                    G5 = color;
                if (r == 6)
                    G6 = color;
            }
        }


        public ViewModel(int players, int difficulty, bool first)
        {
            initializeRectangleColors();
            if (players == 2)
                this.playerManager = new PlayerManager(1);
            else if(players == 1)
            {
                if (difficulty == 5)
                    this.playerManager = new PlayerManager(2);
                if (difficulty == 1)
                    this.playerManager = new PlayerManager(3);
                if (difficulty == 10)
                    this.playerManager = new PlayerManager(4);
                if (!first)
                    changeColor(this.playerManager.b.addRed(3) , 3);
            }
            else
            {
                this.playerManager = new PlayerManager(5);
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                        changeColor(i, j);
                }

            }

        }

        public void ColumnClicked(char column)
        {
            int c = ConvertCharToIntColumn(column);
            int r = playerManager.ColumnClicked(c);
            for(int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                    changeColor(i, j);
            }
            
        }

        public int ConvertCharToIntColumn(char column)
        {
            int c = -1;
            switch (column)
            {
                case 'A':
                    c = 0;
                    break;
                case 'B':
                    c = 1;
                    break;
                case 'C':
                    c = 2;
                    break;
                case 'D':
                    c = 3;
                    break;
                case 'E':
                    c = 4;
                    break;
                case 'F':
                    c = 5;
                    break;
                case 'G':
                    c = 6;
                    break;
                default:
                    break;
            }
            return c;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void updateProperty(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
