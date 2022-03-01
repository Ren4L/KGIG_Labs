using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Лаба_2
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
        private bool move = false;
        private bool cut = false;
        private Point point;
        private void Can1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            move = true;
            point = e.GetPosition(Can1);
        }

        private void Can1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            move = false;
        }

        private void Can1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                Canvas.SetLeft(Rect1, Math.Min(point.X, e.GetPosition(Can1).X));
                Canvas.SetTop(Rect1, Math.Min(point.Y, e.GetPosition(Can1).Y));
                Rect1.Width = Math.Abs(e.GetPosition(Can1).X - point.X);
                Rect1.Height = Math.Abs(e.GetPosition(Can1).Y - point.Y);
                cut = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Rect rect = new Rect(Canvas.GetLeft(Rect1), Canvas.GetTop(Rect1), Rect1.Width, Rect1.Height);
            System.Windows.Int32Rect rc = new System.Windows.Int32Rect();
            rc.X = (int)rect.X;
            rc.Y = (int)rect.Y;
            rc.Width = (int)rect.Width;
            rc.Height = (int)rect.Height;
            Rect1.Opacity = 0;
            Transform t = Can1.LayoutTransform;
            Can1.LayoutTransform = null;
            Size size = new Size(Can1.ActualWidth, Can1.ActualHeight);

            Can1.Arrange(new Rect(size));
            RenderTargetBitmap RTB = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96d, 96d, PixelFormats.Pbgra32);
            RTB.Render(Can1);
            Image Crop = new Image();
            Crop.Source = RTB;
            Crop.Width = Can1.ActualWidth;
            Crop.Height = Can1.ActualHeight;
            Crop.Stretch = Stretch.None;
            Crop.Margin = new Thickness(0);

            BitmapSource bs = new CroppedBitmap(Crop.Source as BitmapSource, rc);
            img2.Source = bs;
            Rect1.Opacity = 0.6;

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                XY xy = new XY();
                if (xy.ShowDialog() == true)
                {
                    OpenFileDialog OF = new OpenFileDialog();
                    if (OF.ShowDialog() == true)
                    {
                        Canvas.SetLeft(img1, xy.x1);
                        Canvas.SetTop(img1, xy.y1);
                        BitmapImage BI = new BitmapImage();
                        BI.BeginInit();
                        BI.UriSource = new Uri(OF.FileName);
                        BI.EndInit();
                        img1.Source = BI;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SF = new SaveFileDialog(); 
            SF.Filter = "Bitmap (.bmp)|*.bmp";
            if (SF.ShowDialog() == true)
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)img2.Source));
                using (FileStream stream = new FileStream(SF.FileName, FileMode.Create))
                    encoder.Save(stream);
            }
        }
    }
}
