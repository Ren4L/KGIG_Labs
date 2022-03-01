using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_6
{
    public class CPlot3D
    {
        const double MAX = 1.7976931348623158e+308;
        const double MIN = 2.2250738585072014e-308;
        public CMatrix[] MathWorld;
        public CMatrix MathScreen;
        public CMatrix MathView;
        public CMatrix View;
        public CRect WRect;
        public double dx;
        public double dy;
        public CPlot3D(CRect wRect, CMatrix view, double Dx, double Dy)
        {
            (WRect, View, dx, dy) = (wRect, view, Dx, Dy);
        }
        public void Func(Func<double, double, double> func)
        {
            CreateWorld(func);
        }

        public void CreateWorld(Func<double, double, double> func)
        {
            CMatrix V = new CMatrix(4,1);
            V[3, 0] = 1;
            for (double x = WRect.Xl; x <= WRect.Xh; x += dx)
            {
                for (double y = WRect.Yl; y <= WRect.Yh; y += dy)
                {
                    V[0,0] = x;
                    V[1,0] = y;
                    V[2,0] = func(x, y);
                }
                MathWorld.Append(V);
            }
        }
        public void CreateView()
        {
            CMatrix CVC = CMatrix.getConverterWorldToView(this.View);
            for (int i = 0; i < MathWorld.Length; i++)
            {
                VecMatrix.clear();
                for (int j = 0; j < MatrF[i].size(); j++)
                {
                    VX = MatrF[i][j];
                    VX = MV * VX;
                    V(0) = VX(0);
                    V(1) = VX(1);
                    VecMatrix.push_back(V);

                    double x = V(0);
                    double y = V(1);
                    if (x < xmin) xmin = x;
                    if (x > xmax) xmax = x;
                    if (y < ymin) ymin = y;
                    if (y > ymax) ymax = y;
                }
                MatrView.push_back(VecMatrix);
            }
        }
    }
}
