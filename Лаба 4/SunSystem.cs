using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
    public class SunSystem
    {
        public static CMatrix CreateRotate2D(double f)
        {
            double buf = ((f % 360.0) / 180.0) * Math.PI;
            CMatrix rad = new CMatrix(3, 3);
            rad[0, 0] = Math.Cos(buf);
            rad[1, 0] = Math.Sin(buf);
            rad[2, 2] = 1;

            rad[0, 1] = -Math.Sin(buf);
            rad[1, 1] = Math.Cos(buf);
            return rad;
        }

        public static CMatrix CreateTranslate2D(double dx, double dy)
        {
            CMatrix rad = new CMatrix(3, 3);
            rad[0, 0] = 1;
            rad[1, 1] = 1;
            rad[2, 2] = 1;

            rad[0, 2] = dx;
            rad[1, 2] = dy;
            return rad;
        }
    }
}
