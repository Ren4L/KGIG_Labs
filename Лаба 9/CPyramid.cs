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

namespace Лаба_9
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
        const double MAX = 1.7976931348623158e+308;
        const double MIN = 2.2250738585072014e-308;
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

        public static void ColorDraw(Canvas Can, CMatrix View, CRect W, CMatrix color)
        {

            try
            {
                CPyramid pyramid = new CPyramid();
                byte red = Convert.ToByte(color[0, 0]);
                byte green = Convert.ToByte(color[1, 0]);
                byte blue = Convert.ToByte(color[2, 0]);
                CMatrix ViewCart = CMatrixMethod.SphereToCart(View);
                CMatrix MV = CMatrix.getConverterWorldToView(View);
                CMatrix ViewVert = MV * pyramid.points;

                double xmin = MAX;
                double xmax = MIN;
                double ymin = MAX;
                double ymax = MIN;

                for (int i = 0; i < pyramid.points.column; i++)
                {
                    if (pyramid.points[0, i] < xmin) xmin = pyramid.points[0, i];
                    if (pyramid.points[0, i] > xmax) xmax = pyramid.points[0, i];
                    if (pyramid.points[1, i] < ymin) ymin = pyramid.points[1, i];
                    if (pyramid.points[1, i] > ymax) ymax = pyramid.points[1, i];
                }
                CRect S = new CRect(xmin, ymin, xmax, ymax);
                CMatrix MW = CMatrix.SpaceToWindow(W, S);
                Point[] MasVert = new Point[6];

                for (int i = 0; i < 6; i++)
                {
                    CMatrix V = new CMatrix(3, 1);
                    V[0, 0] = ViewVert[0, i];
                    V[1, 0] = ViewVert[1, i];
                    V[2, 0] = 1;
                    V = MW * V;
                    MasVert[i].X = V[0, 0];
                    MasVert[i].Y = V[1, 0];
                }
                CMatrix R1 = new CMatrix(3, 1);
                CMatrix R2 = new CMatrix(3, 1);
                CMatrix VN = new CMatrix(3, 1);
                double sm;
                for (int i = 0; i < 3; i++)
                {
                    CMatrix VE = pyramid.points.GetColumn(i + 3);
                    VE.RedimData(3);
                    int k;
                    if (i == 2) k = 0;
                    else k = i + 1;

                    R1 = pyramid.points.GetColumn(i);
                    R1.RedimData(3);
                    R2 = pyramid.points.GetColumn(k);
                    R2.RedimData(3);

                    CMatrix V1 = R2 - R1;
                    CMatrix V2 = VE - R1;
                    VN = CMatrixMethod.VectorMult(V2, V1);
                    sm = CMatrixMethod.CosV1V2(VN, ViewCart);

                    if(sm >= 0)
                    {
                        Polygon polygon = new Polygon();
                        polygon.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(color[0, 0] * sm*sm), Convert.ToByte(color[1, 0] * sm * sm), Convert.ToByte(color[2, 0] * sm * sm)));
                        PointCollection PC = new PointCollection();
                        PC.Add(MasVert[i]);
                        PC.Add(MasVert[k]);
                        PC.Add(MasVert[k+3]);
                        PC.Add(MasVert[i+3]);
                        polygon.Points = PC;
                        Can.Children.Add(polygon);
                    }
                    VN = CMatrixMethod.VectorMult(R1, R2);
                    sm = CMatrixMethod.CosV1V2(VN, ViewCart);
                    if (sm >= 0)
                    {
                        Polygon polygon = new Polygon();
                        polygon.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sm * 0.3), Convert.ToByte(sm * 0.3), Convert.ToByte(sm*0.3)));
                        PointCollection PC = new PointCollection();
                        PC.Add(MasVert[0]);
                        PC.Add(MasVert[1]);
                        PC.Add(MasVert[2]);
                        polygon.Points = PC;
                        Can.Children.Add(polygon);
                    }
                    else
                    {
                        Polygon polygon = new Polygon();
                        polygon.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sm * 0.7), Convert.ToByte(sm * 0.7), Convert.ToByte(sm * 0.7)));
                        PointCollection PC = new PointCollection();
                        PC.Add(MasVert[3]);
                        PC.Add(MasVert[4]);
                        PC.Add(MasVert[5]);
                        polygon.Points = PC;
                        Can.Children.Add(polygon);
                    }
                }
            }
            catch(Exception e)
            {
            }
        }
        public static void DrawLightSphere(Canvas Can, double Radius, CMatrix View, CMatrix SourceLight, CRect W, CMatrix color, int index)
        {
            try
            {
                double df = 0.9; double dq = 0.6;

                for (double fi = 0; fi <= 360.0; fi += df)
                {
                    for (double q = 0; q <= 180.0; q += dq)
                    {
                        CMatrix VR = CMatrixMethod.SphereToCart(View);
                        CMatrix VS = CMatrixMethod.SphereToCart(SourceLight);
                        CRect RV = new CRect(-Radius, -Radius, Radius, Radius);
                        CMatrix MW = CMatrix.SpaceToWindow(W, RV);
                        CMatrix MV = CMatrix.getConverterWorldToView(View);
                        CMatrix VSphere = new CMatrix(3, 1);
                        VSphere[0, 0] = Radius;
                        CMatrix VSphereNorm = new CMatrix(3, 1);
                        CMatrix PV = new CMatrix(4, 1);
                        VSphere[1, 0] = fi;
                        VSphere[2, 0] = q;
                        CMatrix VCart = CMatrixMethod.SphereToCart(VSphere);
                        VSphereNorm = VCart;
                        double cos_RN = CMatrixMethod.CosV1V2(VR, VSphereNorm);
                        PV[0, 0] = VCart[0, 0];
                        PV[1, 0] = VCart[1, 0];
                        PV[2, 0] = VCart[2, 0];
                        PV[3, 0] = 1;
                        PV = MV * PV;
                        VCart[0, 0] = PV[0, 0];
                        VCart[1, 0] = PV[1, 0];
                        VCart[2, 0] = 1;
                        VCart = MW * VCart;
                        CMatrix VP = VS - VR;
                        double cos_PN = CMatrixMethod.CosV1V2(VP, VSphereNorm);
                        if (cos_PN > 0)
                        {
                            double kLight = 0;
                            if (index == 0)
                            {
                                kLight = Math.Abs(cos_PN * cos_RN);
                            }
                            if (index == 1)
                            {
                                double xx = 2 * CMatrixMethod.ModVec(VP) * cos_PN / CMatrixMethod.ModVec(VSphereNorm);
                                CMatrix RX = (VSphereNorm * xx) - VP;
                                double cos_A = CMatrixMethod.CosV1V2(RX, VR);
                                if (cos_A > 0) kLight = cos_A * cos_A;
                                else kLight = 0;
                            }
                            SolidColorBrush Col = new SolidColorBrush(Color.FromRgb(Convert.ToByte(color[0, 0] * kLight), Convert.ToByte(color[1, 0] * kLight), Convert.ToByte(color[2, 0] * kLight)));
                            Ellipse el = new Ellipse();
                            el.Width = 5;
                            el.Height = 5;
                            el.Fill = Col;
                            Canvas.SetLeft(el, VCart[0, 0]);
                            Canvas.SetTop(el, VCart[1, 0]);
                            Can.Children.Add(el);

                        }

                    }
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
