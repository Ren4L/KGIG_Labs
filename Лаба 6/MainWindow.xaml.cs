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

        public double func1(double x, double y)
        {
            return x * x + y * y;
        }

        private void Func1_Click(object sender, RoutedEventArgs e)
        {
            double dx = 0.25, dy = 0.25;
            CRect S = new CRect(0, 0, 700, 700);
            CRect W = new CRect(-350, -350, 350, 350);
            CMatrix ToScreen = CMatrix.SpaceToWindow(S, W);
            CPlot3D.Func(func1, dx, dy);
        }
    }
}
