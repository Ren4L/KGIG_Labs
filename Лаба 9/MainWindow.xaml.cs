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

namespace Лаба_9
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

        public CMatrix View = new CMatrix(100, 0, 60);
        public CRect W = new CRect(0, 0, 700, 700);

        private void Lagran_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            CRect S = new CRect(-5, -5, 5, 5);
            CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            Bezie.Lagrange(Can, ToScreen);
        }

        private void Bezie1_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            CRect S = new CRect(-10, -10, 10, 10);
            CMatrix X = new CMatrix(3, 1);
            CMatrix Y = new CMatrix(3, 1);
            X[0, 0] = 0;
            Y[0, 0] = 0;
            X[1, 0] = -15;
            Y[1, 0] = 5;
            X[2, 0] = 10;
            Y[2, 0] = 0;
            int N = 50;
            CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            Bezie.Bezie1(Can, X, Y, ToScreen, N);
        }

        private void Bezie2_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            CRect S = new CRect(-10, -10, 10, 10);
            CMatrix X = new CMatrix(3, 1);
            CMatrix Y = new CMatrix(3, 1);
            X[0, 0] = 0;
            Y[0, 0] = 0;
            X[1, 0] = 5;
            Y[1, 0] = 5;
            X[2, 0] = 10;
            Y[2, 0] = 0;
            int N = 50;
            CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            Bezie.Bezie1(Can, X, Y, ToScreen, N);
        }

        private void Bezie3_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            CRect S = new CRect(-20, -10, 20, 10);
            CMatrix X = new CMatrix(4, 1);
            CMatrix Y = new CMatrix(4, 1);
            X[0, 0] = 0;
            Y[0, 0] = 0;
            X[1, 0] = 5;
            Y[1, 0] = 10;
            X[2, 0] = 10;
            Y[2, 0] = -10;
            X[3, 0] = 15;
            Y[3, 0] = 0;
            int N = 50;
            CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            Bezie.Bezie1(Can, X, Y, ToScreen, N);
        }

        private void Bezie4_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            CRect S = new CRect(-20, -10, 20, 10);
            CMatrix X = new CMatrix(4, 1);
            CMatrix Y = new CMatrix(4, 1);
            X[0, 0] = 0;
            Y[0, 0] = 0;
            X[1, 0] = 20;
            Y[1, 0] = 10;
            X[2, 0] = -5;
            Y[2, 0] = 10;
            X[3, 0] = 15;
            Y[3, 0] = 0;
            int N = 50;
            CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            Bezie.Bezie1(Can, X, Y, ToScreen, N);
        }
    }
}
