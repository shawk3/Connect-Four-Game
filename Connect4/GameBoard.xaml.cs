﻿using System;
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
    public partial class GameBoard : Window
    {
        public ViewModel viewModel;
        public GameBoard(int players, int difficulty, bool first)
        {
            this.viewModel = new ViewModel(players, difficulty, first);
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void Column_Click(object sender, RoutedEventArgs e)
        {
            Button s = sender as Button;
            viewModel.ColumnClicked(Convert.ToChar(s.Content));

        }
    }
}