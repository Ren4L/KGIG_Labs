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
using System.Windows.Threading;

namespace Лаба_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Animate;
        }
        DispatcherTimer timer = new DispatcherTimer();
        double fiV = 1;   
        double fiE = 0;
        double fiM = 0;
        double fiP = 0;
        double wMars = -4;          // Угловая скорость Луны в системе кординат Земли, град/сек.
        double wPo = -15;
        double wEarth = 10;
        double wMoon = 20;
        double dt = 0.1;
        double RoV = 100;
        double RoE = 200;
        double RoM = 60;
        double RoP = 40;
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        public void Animate(object sender, EventArgs e)
        {
            CRect W = new CRect(0, 0, 600, 600);
            CRect S = new CRect(-300, -300, 300, 300);
            

            double fmo = (fiM / 180.0) * Math.PI;                     // Радианы - угловое положение Луны в СК Земли
            double xmo = RoM * Math.Cos(fmo);                           // x - начальная координата Луны в СК Земли
            double ymo = RoM * Math.Sin(fmo);                           // y - начальная координата Луны в СК Земли	
            CMatrix MOCoords = new CMatrix(3, 1);
            MOCoords[0, 0] = xmo;
            MOCoords[1, 0] = ymo;
            MOCoords[2, 0] = 1;
            fiM += wMoon * dt;
            CMatrix PMO = SunSystem.CreateRotate2D(fiM);                   // Матрица поворота против часовой стрелки Луны
            MOCoords = PMO * MOCoords;

            double fp = (fiP / 180.0) * Math.PI;                     
            double xp = RoP * Math.Cos(fp);                          
            double yp = RoP * Math.Sin(fp);                          
            CMatrix PCoords = new CMatrix(3, 1);
            PCoords[0, 0] = xp;
            PCoords[1, 0] = yp;
            PCoords[2, 0] = 1;
            fiP += wPo * dt;
            CMatrix PP = SunSystem.CreateRotate2D(fiP);                   
            PCoords = PP * PCoords;

            double fe = (fiE / 180.0) * Math.PI;
            double xe = RoE * Math.Cos(fe);
            double ye = RoE * Math.Sin(fe);
            CMatrix ECoords = new CMatrix(3, 1);
            ECoords[0, 0] = xe;
            ECoords[1, 0] = ye;
            ECoords[2, 0] = 1;
            CMatrix PE = SunSystem.CreateTranslate2D(xe, ye);
            MOCoords = PE * MOCoords;
            PCoords = PE * PCoords;

            fiE += wEarth * dt;
            CMatrix P = SunSystem.CreateRotate2D(fiE);                            
            MOCoords = P * MOCoords;
            ECoords = P * ECoords;
            PCoords = P * PCoords;

            MOCoords = CMatrix.SpaceToWindow(W, S) * MOCoords;
            ECoords = CMatrix.SpaceToWindow(W, S) * ECoords;
            PCoords = CMatrix.SpaceToWindow(W, S) * PCoords;

            Canvas.SetLeft(Earth, ECoords[0, 0] - 20);
            Canvas.SetTop(Earth, ECoords[1, 0] - 20);

            Canvas.SetLeft(MoonORB, ECoords[0, 0] - 60);
            Canvas.SetTop(MoonORB, ECoords[1, 0] - 60);

            Canvas.SetLeft(Moon, MOCoords[0, 0] - 10);
            Canvas.SetTop(Moon, MOCoords[1, 0] - 10);


            Canvas.SetLeft(poORB, ECoords[0, 0] - 40);
            Canvas.SetTop(poORB, ECoords[1, 0] - 40);

            Canvas.SetLeft(Po, PCoords[0, 0] - 10);
            Canvas.SetTop(Po, PCoords[1, 0] - 10);

            double fm = (fiV / 180.0) * Math.PI;
            double xm = RoV * Math.Cos(fm);
            double ym = RoV * Math.Sin(fm);
            CMatrix MCoords = new CMatrix(3, 1);
            MCoords[0, 0] = xm;
            MCoords[1, 0] = ym;
            MCoords[2, 0] = 1;
            fiV += wMars * dt;
            CMatrix PM = SunSystem.CreateRotate2D(fiV);
            MCoords = PM * MCoords;
            MCoords = CMatrix.SpaceToWindow(W, S) * MCoords;
            Canvas.SetLeft(Mars, MCoords[0, 0] - 15);
            Canvas.SetTop(Mars, MCoords[1, 0] - 15);
        }
    }
}
