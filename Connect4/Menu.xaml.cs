using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Connect4
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        GameBoard boardWindow;
        int Difficulty = 1;
        bool first = true;

        public Menu()
        {
            InitializeComponent();
        }

        private void TwoPlayer_Click(object sender, RoutedEventArgs e)
        {
            boardWindow = new GameBoard(2, Difficulty, first);
            boardWindow.Show();

        }

        private void OnePlayer_Click(object sender, RoutedEventArgs e)
        {
            boardWindow = new GameBoard(1, Difficulty, first);
            boardWindow.Show();
        }

        private void TrainFred_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                boardWindow = new GameBoard(0, Difficulty, first);
                boardWindow.Show();
            }

        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 1;
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 5;
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 10;
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            first = true;
        }

        private void Second_Click(object sender, RoutedEventArgs e)
        {
            first = false;
        }
            
    }
}
