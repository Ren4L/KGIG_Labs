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

namespace Лаба_5
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

        public CMatrix View = new CMatrix(10, 315, 45);
        public bool fMove = false;
        public bool In = true;
        private void Inv_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            In = true;
            CPyramid.Pyramid(View, Can);
        }

        private void NInv_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            In = false;
            CPyramid.PyramidNInv(View, Can);
        }

        private void Can_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fMove = true;
        }

        private void Can_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            fMove = false;
        }

        private void Can_MouseMove(object sender, MouseEventArgs e)
        {
            if(fMove == true)
            {
                Can.Children.Clear();
                View[1, 0] += e.GetPosition(Can).X;
                View[2, 0] += e.GetPosition(Can).Y;
                if (In == true)
                {
                    CPyramid.Pyramid(View, Can);
                }
                else
                {
                    CPyramid.PyramidNInv(View, Can);

                }
            }
        }

    }
}
