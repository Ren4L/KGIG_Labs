using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Лаба_9
{
    class Bezie
    {
        public static void GetWindowCoords(CMatrix ToScreen, double xs, double ys, ref int xw, ref int yw)
        {
            CMatrix V = new CMatrix(3, 1);
            CMatrix W = new CMatrix(3, 1);
            V[2, 0] = 1;
            V[0, 0] = xs;
            V[1, 0] = ys;
            W = ToScreen * V;
            xw = (int)W[0,0];
            yw = (int)W[1,0];

        }

        public static double Lagr(CMatrix X, CMatrix Y, double x, int size)
        {
            double lagrange_pol = 0;
            double basics_pol;

            for (int i = 0; i < size; i++)
            {
                basics_pol = 1;
                for (int j = 0; j < size; j++)
                {
                    if (j == i) continue;
                    basics_pol *= (x - X[j,0]) / (X[i,0] - X[j,0]);
                }
                lagrange_pol += basics_pol * Y[i,0];
            }
            return lagrange_pol;
        }

        public static void Lagrange(Canvas Can, CMatrix ToScreen)
        {
            try
            {
                CMatrix X = new CMatrix(3, 1);
                CMatrix Y = new CMatrix(3, 1);

                double dx = Math.PI / 4;
                double xL = 0;
                double xH = Math.PI;

                int N = (int)((xH - xL) / dx);
                X.RedimMatrix(N + 1);
                Y.RedimMatrix(N + 1);

                for (int i = 0; i <= N; i++)
                {
                    X[i, 0] = xL + i * dx;
                    Y[i, 0] = Math.Pow(2 + Math.Cos(X[i,0]), Math.Sin(2 * X[i, 0]));
                }

                dx = 0.1;
                int NL = (int)((xH - xL) / dx);
                CMatrix XL = new CMatrix(NL + 1, 1);
                CMatrix YL = new CMatrix(NL + 1, 1);

                for (int i = 0; i <= NL; i++)
                {
                    XL[i, 0] = xL + i * dx;
                    YL[i, 0] = Lagr(X, Y, XL[i, 0], N + 1);
                }

                for (int i = 0; i < NL; i++)
                {
                    CMatrix Coord1 = new CMatrix(XL[i, 0], YL[i, 0], 1);
                    CMatrix Coord2 = new CMatrix(XL[i+1, 0], YL[i+1, 0], 1);
                    Coord1 = ToScreen * Coord1;
                    Coord2 = ToScreen * Coord2;
                    Line l = new Line();
                    l.Stroke = Brushes.Black;
                    l.StrokeThickness = 2;
                    l.X1 = Coord1[0, 0];
                    l.Y1 = Coord1[1, 0];
                    l.X2 = Coord2[0, 0];
                    l.Y2 = Coord2[1, 0];
                    Can.Children.Add(l);
                }
            }   
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void Bezie1(Canvas Can, CMatrix X, CMatrix Y, CMatrix ToScreen, int NT)
        {
            double xs, ys;
            int xw=0, yw=0;
            double dt = 1.0 / NT;
            int N = X.row;
            CMatrix RX = new CMatrix(N, 1);
            CMatrix RY = new CMatrix(N, 1);
            xs = X[0, 0];
            ys = Y[0, 0];
            GetWindowCoords(ToScreen, xs, ys, ref xw, ref yw);
            for(int k = 1; k <= NT; k++)
            {
                Line l = new Line();
                l.Stroke = Brushes.Black;
                l.StrokeThickness = 2;
                l.X1 = xw;
                l.Y1 = yw;
                double t = k * dt;
                for (int i = 0; i < N; i++)
                {
                    RX[i, 0] = X[i, 0];
                    RY[i, 0] = Y[i, 0];
                }

                for (int j = N - 1; j > 0; j--)
                {
                    for (int i = 0; i < j; i++)
                    {
                        RX[i, 0] = RX[i, 0] + t * (RX[i+1, 0] - RX[i, 0]);
                        RY[i, 0] = RY[i, 0] + t * (RY[i+1, 0] - RY[i, 0]);
                    }
                }
                xs = RX[0, 0];
                ys = RY[0, 0];
                GetWindowCoords(ToScreen, xs, ys, ref xw, ref yw);
                l.X2 = xw;
                l.Y2 = yw;
                Can.Children.Add(l);
            }

        } 
    }
}
