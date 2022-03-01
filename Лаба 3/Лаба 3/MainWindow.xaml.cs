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

namespace Лаба_3
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

        private void F1_Click(object sender, RoutedEventArgs e)
        {
            Canvas canvas = new Canvas();
            canvas.Width = 300;
            canvas.Height = 350;
            canvas.Background = System.Windows.Media.Brushes.Gray;
            CRect W = new CRect(0, 0, 300, 350);
            double[] Xarr = { };
            int XSize = 1;
            double[] Yarr = { };
            int YSize = 1;
            for (double i = -3 * Math.PI; i < 3 * Math.PI; i += Math.PI / 36)
            {
                Array.Resize(ref Xarr, XSize);
                Xarr[XSize - 1] = i;
                XSize++;
                Array.Resize(ref Yarr, YSize);
                Yarr[YSize - 1] = Math.Sin(i)/i;
                YSize++;
            }
            CRect S = new CRect(Xarr.Min(), Yarr.Min(), Xarr.Max(), Yarr.Max());
            Line OY = new Line();
            OY.X1 = 150;
            OY.Y1 = 0;
            OY.X2 = 150;
            OY.Y2 = 350;
            OY.Stroke = Brushes.Blue;
            OY.StrokeThickness = 2;
            canvas.Children.Add(OY);
            Line OX = new Line();
            CMatrix p = new CMatrix(3, 1);
            p[0, 0] = Xarr[0];
            p[1, 0] = Yarr[0];
            p[2, 0] = 1;
            CMatrix bufp = CMatrix.SpaceToWindow(W, S) * p;
            OX.X1 = bufp[0, 0];
            OX.Y1 = bufp[1, 0];
            CMatrix p1 = new CMatrix(3, 1);
            p1[0, 0] = Xarr[Xarr.Length-1];
            p1[1, 0] = Yarr[Xarr.Length - 1];
            p1[2, 0] = 1;
            CMatrix bufp1 = CMatrix.SpaceToWindow(W, S) * p1;
            OX.X2 = bufp1[0, 0];
            OX.Y2 = bufp1[1, 0];
            OX.Stroke = Brushes.Blue;
            OX.StrokeThickness = 2;
            canvas.Children.Add(OX);
            int flag = 1;
            for(double i = -3 * Math.PI; i < 3 * Math.PI; i += Math.PI / 36)
            {
                if (flag<Xarr.Length)
                {
                    Line line = new Line();
                    line.Stroke = System.Windows.Media.Brushes.Red;
                    line.StrokeThickness = 1;
                    CMatrix b = new CMatrix(3, 1);
                    b[0, 0] = Xarr[flag - 1];
                    b[1, 0] = Yarr[flag - 1];
                    b[2, 0] = 1;
                    CMatrix buf = CMatrix.SpaceToWindow(W, S) * b;
                    line.X1 = buf[0, 0];
                    line.Y1 = buf[1, 0];
                    CMatrix b1 = new CMatrix(3, 1);
                    b1[0, 0] = Xarr[flag];
                    b1[1, 0] = Yarr[flag];
                    b1[2, 0] = 1;
                    CMatrix buf1 = CMatrix.SpaceToWindow(W, S) * b1;
                    line.X2 = buf1[0, 0];
                    line.Y2 = buf1[1, 0];
                    canvas.Children.Add(line);
                    flag++;
                }
            }
            GR.Children.Add(canvas);
        }

        private void F2_Click(object sender, RoutedEventArgs e)
        {
            Canvas canvas = new Canvas();
            canvas.Width = 300;
            canvas.Height = 350;
            canvas.Background = System.Windows.Media.Brushes.Gray;
            CRect W = new CRect(0, 0, 300, 350);
            double[] Xarr = { };
            int XSize = 1;
            double[] Yarr = { };
            int YSize = 1;
            for (double i = -5; i < 5; i += 0.25)
            {
                Array.Resize(ref Xarr, XSize);
                Xarr[XSize - 1] = i;
                XSize++;
                Array.Resize(ref Yarr, YSize);
                Yarr[YSize - 1] = Math.Pow(i,3);
                YSize++;
            }
            CRect S = new CRect(Xarr.Min(), Yarr.Min(), Xarr.Max(), Yarr.Max());
            Line OY = new Line();
            OY.X1 = 150;
            OY.Y1 = 0;
            OY.X2 = 150;
            OY.Y2 = 350;
            OY.Stroke = Brushes.Blue;
            OY.StrokeThickness = 2;
            canvas.Children.Add(OY); 
            
            Line OX = new Line();
            OX.X1 = 0;
            OX.Y1 = 162;
            OX.X2 = 300;
            OX.Y2 = 162;
            OX.Stroke = Brushes.Blue;
            OX.StrokeThickness = 2;
            canvas.Children.Add(OX);
            int flag = 1;
            for (double i = -5; i < 5; i += 0.25)
            {
                if (flag < Xarr.Length)
                {
                    Line line = new Line();
                    line.Stroke = System.Windows.Media.Brushes.Green;
                    line.StrokeThickness = 1;
                    CMatrix b = new CMatrix(3, 1);
                    b[0, 0] = Xarr[flag - 1];
                    b[1, 0] = Yarr[flag - 1];
                    b[2, 0] = 1;
                    CMatrix buf = CMatrix.SpaceToWindow(W, S) * b;
                    line.X1 = buf[0, 0];
                    line.Y1 = buf[1, 0];
                    CMatrix b1 = new CMatrix(3, 1);
                    b1[0, 0] = Xarr[flag];
                    b1[1, 0] = Yarr[flag];
                    b1[2, 0] = 1;
                    CMatrix buf1 = CMatrix.SpaceToWindow(W, S) * b1;
                    line.X2 = buf1[0, 0];
                    line.Y2 = buf1[1, 0];
                    canvas.Children.Add(line);
                    flag++;
                }
            }
            GR2.Children.Add(canvas);
        }

        private void F3_Click(object sender, RoutedEventArgs e)
        {
            Canvas canvas = new Canvas();
            canvas.Width = 300;
            canvas.Height = 350;
            canvas.Background = System.Windows.Media.Brushes.Gray;
            CRect W = new CRect(0, 0, 300, 350);
            double[] Xarr = { };
            int XSize = 1;
            double[] Yarr = { };
            int YSize = 1;
            for (double i = 0; i < 6 * Math.PI; i += Math.PI/36)
            {
                Array.Resize(ref Xarr, XSize);
                Xarr[XSize - 1] = i;
                XSize++;
                Array.Resize(ref Yarr, YSize);
                Yarr[YSize - 1] = Math.Sqrt(i) * Math.Sin(i);
                YSize++;
            }
            CRect S = new CRect(Xarr.Min(), Yarr.Min(), Xarr.Max(), Yarr.Max());
            Line OX = new Line();
            OX.X1 = 0;
            OX.Y1 = 175;
            OX.X2 = 300;
            OX.Y2 = 175;
            OX.Stroke = Brushes.Black;
            OX.StrokeThickness = 2;
            canvas.Children.Add(OX);
            int flag = 1;
            for (double i = 0; i < 6 * Math.PI; i += Math.PI / 36)
            {
                if (flag < Xarr.Length)
                {
                    Line line = new Line();
                    line.Stroke = System.Windows.Media.Brushes.Red;
                    line.StrokeThickness = 3;
                    line.StrokeDashArray = new DoubleCollection() { 3 };
                    CMatrix b = new CMatrix(3, 1);
                    b[0, 0] = Xarr[flag - 1];
                    b[1, 0] = Yarr[flag - 1];
                    b[2, 0] = 1;
                    CMatrix buf = CMatrix.SpaceToWindow(W, S) * b;
                    line.X1 = buf[0, 0];
                    line.Y1 = buf[1, 0];
                    CMatrix b1 = new CMatrix(3, 1);
                    b1[0, 0] = Xarr[flag];
                    b1[1, 0] = Yarr[flag];
                    b1[2, 0] = 1;
                    CMatrix buf1 = CMatrix.SpaceToWindow(W, S) * b1;
                    line.X2 = buf1[0, 0];
                    line.Y2 = buf1[1, 0];
                    canvas.Children.Add(line);
                    flag++;
                }
            }
            GR3.Children.Add(canvas);
        }

        private void F4_Click(object sender, RoutedEventArgs e)
        {
            Canvas canvas = new Canvas();
            canvas.Width = 300;
            canvas.Height = 350;
            canvas.Background = System.Windows.Media.Brushes.Gray;
            CRect W = new CRect(0, 0, 300, 350);
            double[] Xarr = { };
            int XSize = 1;
            double[] Yarr = { };
            int YSize = 1;
            for (double i = -10; i < 10; i += 0.25)
            {
                Array.Resize(ref Xarr, XSize);
                Xarr[XSize - 1] = i;
                XSize++;
                Array.Resize(ref Yarr, YSize);
                Yarr[YSize - 1] = i*i;
                YSize++;
            }
            CRect S = new CRect(Xarr.Min(), Yarr.Min(), Xarr.Max(), Yarr.Max());
            Line OY = new Line();
            OY.X1 = 150;
            OY.Y1 = 0;
            OY.X2 = 150;
            OY.Y2 = 350;
            OY.Stroke = Brushes.Blue;
            OY.StrokeThickness = 2;
            canvas.Children.Add(OY);
            int flag = 1;
            for (double i = -10; i < 10; i += 0.25)
            {
                if (flag < Xarr.Length)
                {
                    Line line = new Line();
                    line.Stroke = System.Windows.Media.Brushes.Red;
                    line.StrokeThickness = 2;
                    CMatrix b = new CMatrix(3, 1);
                    b[0, 0] = Xarr[flag - 1];
                    b[1, 0] = Yarr[flag - 1];
                    b[2, 0] = 1;
                    CMatrix buf = CMatrix.SpaceToWindow(W, S) * b;
                    line.X1 = buf[0, 0];
                    line.Y1 = buf[1, 0];
                    CMatrix b1 = new CMatrix(3, 1);
                    b1[0, 0] = Xarr[flag];
                    b1[1, 0] = Yarr[flag];
                    b1[2, 0] = 1;
                    CMatrix buf1 = CMatrix.SpaceToWindow(W, S) * b1;
                    line.X2 = buf1[0, 0];
                    line.Y2 = buf1[1, 0];
                    canvas.Children.Add(line);
                    flag++;
                }
            }
            GR4.Children.Add(canvas);
        }
    }
}
