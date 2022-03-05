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

namespace Лаба_8
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
        public CRect W = new CRect(200, 200, 500, 500);
        public CMatrix Color1 = new CMatrix(0, 255, 0);
        public CMatrix Color2 = new CMatrix(255, 0, 0);
        public CMatrix Light = new CMatrix(255, 255, 0);
        public CMatrix Light2 = new CMatrix(255, 55, -20);
        public bool fMove = false;

        private void Inv_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            CPyramid.DrawLightSphere(Can, 5, View, Light, W, Color1, 0);
        }


        private void NInv_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
            CPyramid.DrawLightSphere(Can, 1, View, Light2, W, Color2, 1);
        }
    }
}
