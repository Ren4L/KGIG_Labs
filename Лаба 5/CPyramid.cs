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
    public class CPyramid
    {
        public CMatrix points = new CMatrix(4,8);
        public CPyramid()
        {
            points[0, 0] = 180;
            points[0, 3] = 60;
            points[2, 3] = 180;

            points[1, 1] = -180;
            points[1, 4] = -60;
            points[2, 4] = 180;

            points[0, 2] = -180;
            points[0, 5] = -60;
            points[2, 5] = 180;
        }
        public static void Pyramid(CMatrix View, Canvas Can)
        {
            try
            {
                CRect W = new CRect(0, 0, 700, 700);
                CRect S = new CRect(-350, -350, 350, 350);
                CPyramid pyramid = new CPyramid();
                CMatrix ConvertToView = CMatrix.getConverterWorldToView(View);
                CMatrix PointsView = ConvertToView * pyramid.points;
                CMatrix ToWindow = CMatrix.SpaceToWindow(W, S);
                Point[] point = new Point[6];
                CMatrix PointsCoords = new CMatrix(3, 1);
                PointsCoords[2, 0] = 1;
                for (int i = 0; i < 6; i++)
                {
                    PointsCoords[0, 0] = PointsView[0, i];
                    PointsCoords[1, 0] = PointsView[1, i];
                    PointsCoords = ToWindow * PointsCoords;
                    point[i].X = (int)PointsCoords[0, 0];
                    point[i].Y = (int)PointsCoords[1, 0];
                }
                int flag = 1;
                for (int i = 0; i < 6; i++)
                {
                    Line L = new Line();
                    L.Stroke = Brushes.DarkBlue;
                    L.StrokeThickness = 3;
                    L.X1 = point[flag - 1].X;
                    L.Y1 = point[flag - 1].Y;
                    if (flag == 3)
                    {
                        L.X2 = point[0].X;
                        L.Y2 = point[0].Y;
                    }
                    else if (flag == 6)
                    {
                        L.X2 = point[3].X;
                        L.Y2 = point[3].Y;
                    }
                    else
                    {
                        L.X2 = point[flag].X;
                        L.Y2 = point[flag].Y;
                    }
                    flag++;
                    Can.Children.Add(L);
                }

                for (int i = 0; i < 3; i++)
                {
                    Line L = new Line();
                    L.Stroke = Brushes.DarkBlue;
                    L.StrokeThickness = 3;
                    L.X1 = point[i].X;
                    L.Y1 = point[i].Y;
                    L.X2 = point[i + 3].X;
                    L.Y2 = point[i + 3].Y;
                    Can.Children.Add(L);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public static void PyramidNInv(CMatrix View, Canvas Can)
        {
            try
            {
                CRect W = new CRect(0, 0, 700, 700);
                CRect S = new CRect(-350, -350, 350, 350);
                CPyramid pyramid = new CPyramid();
                CMatrix ConvertToCart = CMatrixMethod.SphereToCart(View);
                CMatrix ConvertToView = CMatrix.getConverterWorldToView(View);
                CMatrix PointsView = ConvertToView * pyramid.points;
                CMatrix ToWindow = CMatrix.SpaceToWindow(W, S);
                Point[] point = new Point[6];
                CMatrix PointsCoords = new CMatrix(3, 1);
                PointsCoords[2, 0] = 1;
                for (int i = 0; i < 6; i++)
                {
                    PointsCoords[0, 0] = PointsView[0, i];
                    PointsCoords[1, 0] = PointsView[1, i];
                    PointsCoords = ToWindow * PointsCoords;
                    point[i].X = (int)PointsCoords[0, 0];
                    point[i].Y = (int)PointsCoords[1, 0];
                }

                CMatrix R1 = new CMatrix(3, 1);
                CMatrix R2 = new CMatrix(3, 1);
                CMatrix normalOuter = new CMatrix(3, 1);
                double sm;
                for(int i = 0; i < 3; i++)
                {
                    CMatrix VE = pyramid.points.GetColumn(i + 3);
                    int k = i == 2 ? 0 : i + 1;
                    R1 = pyramid.points.GetColumn(i);
                    R2 = pyramid.points.GetColumn(k);
                    CMatrix edgeBase = R2 - R1;
                    CMatrix edgeVertex = VE - R1;
                    normalOuter = CMatrixMethod.VectorMult(edgeVertex, edgeBase);
                    sm = CMatrixMethod.ScalarMult(normalOuter, ConvertToCart);
                    if(sm >= 0)
                    {
                        Line l1 = new Line();
                        l1.Stroke = Brushes.DarkBlue;
                        l1.StrokeThickness = 3;
                        l1.X1 = point[i].X;
                        l1.Y1 = point[i].Y;
                        l1.X2 = point[k].X;
                        l1.Y2 = point[k].Y;

                        Line l2 = new Line();
                        l2.Stroke = Brushes.DarkBlue;
                        l2.StrokeThickness = 3;
                        l2.X1 = point[k].X;
                        l2.Y1 = point[k].Y;
                        l2.X2 = point[k + 3].X;
                        l2.Y2 = point[k + 3].Y;

                        Line l3 = new Line();
                        l3.Stroke = Brushes.DarkBlue;
                        l3.StrokeThickness = 3;
                        l3.X1 = point[k + 3].X;
                        l3.Y1 = point[k + 3].Y;
                        l3.X2 = point[i + 3].X;
                        l3.Y2 = point[i + 3].Y;

                        Line l4 = new Line();
                        l4.Stroke = Brushes.DarkBlue;
                        l4.StrokeThickness = 3;
                        l4.X1 = point[i + 3].X;
                        l4.Y1 = point[i + 3].Y;
                        l4.X2 = point[i].X;
                        l4.Y2 = point[i].Y;

                        Can.Children.Add(l1);
                        Can.Children.Add(l2);
                        Can.Children.Add(l3);
                        Can.Children.Add(l4);
                    }
                }
                if (ConvertToCart[2, 0] < 0)
                {
                    Polygon polygon = new Polygon();
                    polygon.Fill = Brushes.Green;
                    polygon.Stroke = Brushes.DarkBlue;
                    polygon.StrokeThickness = 3;
                    PointCollection pointsColl = new PointCollection();
                    for (int i = 0; i < 3; i++)
                        pointsColl.Add(point[i]);
                    polygon.Points = pointsColl;
                    Can.Children.Add(polygon);
                }
                else
                {
                    Polygon polygon = new Polygon();
                    polygon.Fill = Brushes.Red;
                    polygon.Stroke = Brushes.DarkBlue;
                    polygon.StrokeThickness = 3;
                    PointCollection pointsColl = new PointCollection();
                    for (int i = 0; i < 3; i++)
                        pointsColl.Add(point[i+3]);
                    polygon.Points = pointsColl;
                    Can.Children.Add(polygon);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
