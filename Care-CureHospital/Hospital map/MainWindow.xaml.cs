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

namespace Hospital_map
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void groundFloorClick(object sender, RoutedEventArgs e)
        {
            groundFloor p = new groundFloor();
            p.Show();
            this.Close();

        }

        private void FirstFloor(object sender, RoutedEventArgs e)
     
        {
            firstFloor firstf = new firstFloor();
            firstf.Show();
            this.Close();
        }

        private void Map(object sender, RoutedEventArgs e)
        {
            MainWindow map = new MainWindow();
            map.Show();
            this.Close();
        }

        private void groundFloor2(object sender, RoutedEventArgs e)
        {
            groundFloor2 p = new groundFloor2();
            p.Show();
            this.Close();
        }

        private void SecondFloor(object sender, RoutedEventArgs e)
        {
            firstFloor psprat = new firstFloor();
            psprat.Show();
            this.Close();
        }

        private void Wokrtime(object sender, MouseButtonEventArgs e)
        {
            worktime worktime1 = new worktime();
            worktime1.Show();
        }
    }
}
