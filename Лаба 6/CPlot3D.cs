using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Лаба_6
{
    public class CPlot3D
    {
        const double MAX = 1.7976931348623158e+308;
        const double MIN = 2.2250738585072014e-308;
        public List<List<CMatrix>> MathWorld = new List<List<CMatrix>>();
        public List<List<CMatrix>> MathScreen = new List<List<CMatrix>>();
        public List<List<Point>> MathView = new List<List<Point>>();
        public CMatrix View;
        public CRect SRect;
        public CRect WRect;
        public double dx;
        public double dy;
        public CPlot3D(CRect sRect, CRect wRect, CMatrix view, double Dx, double Dy)
        {
            (SRect, WRect, View, dx, dy) = (sRect, wRect, view, Dx, Dy);
        }
        public void Func(Func<double, double, double> func)
        {
            MathWorld.Clear();
            MathScreen.Clear();
            MathView.Clear();

            CreateWorld(func); 
            CreateScreen();
            CreateView();

        }

        public void CreateWorld(Func<double, double, double> func)
        {
            try
            {
                List<CMatrix> VecMatrix = new List<CMatrix>();
                for (double x = -5; x < 5; x += dx)
                {
                    VecMatrix.Clear();
                    for (double y = -5; y < 5; y += dy)
                    {
                        CMatrix V = new CMatrix(4, 1);
                        V[0, 0] = x;
                        V[1, 0] = y;
                        V[2, 0] = func(x, y);
                        
                        V[3, 0] = 1;
                        VecMatrix.Add(V);
                    }
                    MathWorld.Add(VecMatrix);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + " 1");
            }
        }
        public void CreateScreen()
        {
            try
            {
                CMatrix CVC = CMatrix.getConverterWorldToView(this.View);
                List<CMatrix> VecMatrix = new List<CMatrix>();
                double xmin = MAX;
                double xmax = MIN;
                double ymin = MAX;
                double ymax = MIN;
                for (int i = 0; i < MathWorld.Count; i++)
                {
                    VecMatrix.Clear();
                    for (int j = 0; j < MathWorld[i].Count; j++)
                    {
                        CMatrix VX = new CMatrix(4, 1);
                        CMatrix V = new CMatrix(3, 1);
                        V[2, 0] = 1;
                        VX = MathWorld[i][j];
                        VX = CVC * VX;
                        V[0, 0] = VX[0, 0];
                        V[1, 0] = VX[1, 0];
                        VecMatrix.Add(V);

                        double x = V[0, 0];
                        double y = V[1, 0];
                        if (x < xmin) xmin = x;
                        if (x > xmax) xmax = x;
                        if (y < ymin) ymin = y;
                        if (y > ymax) ymax = y;
                    }
                    MathScreen.Add(VecMatrix);
                }
                SRect = new CRect(xmin, ymin, xmax, ymax);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + " 2");
            }
        }
        public void CreateView()
        {
            try
            {
                CMatrix TS = CMatrix.SpaceToWindow(WRect, SRect);
                List<Point> VecPoint = new List<Point>();
                for (int i = 0; i < MathScreen.Count; i++)
                {
                    VecPoint.Clear();
                    for (int j = 0; j < MathScreen[i].Count; j++)
                    {
                        CMatrix V = new CMatrix(3, 1);
                        V = MathScreen[i][j];
                        V = TS * V;
                        Point P = new Point();
                        P.X = (int)V[0, 0];
                        P.Y = (int)V[1, 0];
                        VecPoint.Add(P);
                    }
                    MathView.Add(VecPoint);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + " 3");
            }
        }
        public void Draw(Canvas Can)
        {
            try
            {
                int nRows = MathView.Count;
                int nCols = MathView[0].Count;
                for (int i = 0; i < nRows - 1; i++)
                    for (int j = 0; j < nCols - 1; j++)
                    {
                        //MessageBox.Show($"{MathView[0][j].X} {MathView[0][j].Y}");
                        Polygon polygon = new Polygon();
                        polygon.Stroke = Brushes.Black;
                        polygon.StrokeThickness = 1;
                        PointCollection pointsColl = new PointCollection();
                        pointsColl.Add(MathView[i][j]);
                        pointsColl.Add(MathView[i][j + 1]);
                        pointsColl.Add(MathView[i + 1][j + 1]);
                        pointsColl.Add(MathView[i + 1][j]);
                        polygon.Points = pointsColl;
                        Can.Children.Add(polygon);
                        
                    }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + " 4");
            }
        }
    }
}
