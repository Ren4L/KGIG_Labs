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

namespace Лаба_6
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

        public CMatrix View = new CMatrix(10, 30, 45);
        public bool fmove = false;
        public int ind = 0;
        public double func1(double x, double y)
        {
            return (x * x) + (y * y);
        }

        public double func2(double x, double y)
        {
            return (x * x) - (y * y);
        }

        public double func3(double x, double y)
        {
            return Math.Sqrt(x * x + y * y) + 3 * Math.Cos(Math.Sqrt(x * x + y * y)) + 5;
        }

        private void Func1_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();

            double dx = 0.25, dy = 0.25;
            CRect W = new CRect(0, 0, 700, 700);
            CRect S = new CRect(-5, -5, 5, 5);
            //CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            CPlot3D Plot = new CPlot3D(S, W, View, dx, dy);
            Plot.Func(func1);
            ind = 1;
            Plot.Draw(Can);
        }

        private void FUnc2_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            double dx = 0.25, dy = 0.25;
            CRect W = new CRect(0, 0, 700, 700);
            CRect S = new CRect(-5, -5, 5, 5);
            //CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            CPlot3D Plot = new CPlot3D(S, W, View, dx, dy);
            Plot.Func(func2);
            ind = 2;
            Plot.Draw(Can);
        }

        private void Func3_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            double dx = 0.25, dy = 0.25;
            CRect W = new CRect(0, 0, 700, 700);
            CRect S = new CRect(-5, -5, 5, 5);
            //CMatrix ToScreen = CMatrix.SpaceToWindow(W, S);
            CPlot3D Plot = new CPlot3D(S, W, View, dx, dy);
            Plot.Func(func3);
            ind = 3;
            Plot.Draw(Can);
        }

        private void Can_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fmove = true;
        }

        private void Can_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            fmove = false;
        }

        private void Can_MouseMove(object sender, MouseEventArgs e)
        {
            if(fmove == true)
            {
                Can.Children.Clear();
                View[1, 0] += e.GetPosition(Can).X;
                View[2, 0] += e.GetPosition(Can).Y; double dx = 0.25, dy = 0.25;
                CRect W = new CRect(0, 0, 700, 700);
                CRect S = new CRect(-5, -5, 5, 5);
                CPlot3D Plot = new CPlot3D(S, W, View, dx, dy);
                switch (ind)
                {
                    case 1:
                        Plot.Func(func1);
                        break;
                    case 2:
                        Plot.Func(func2);
                        break;
                    case 3:
                        Plot.Func(func3);
                        break;
                }
                Plot.Draw(Can);
            }
        }
    }
}
