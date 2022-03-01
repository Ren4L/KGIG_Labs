using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_3
{
    public class CRect
    {
		public double Xl;
		public double Yl;
		public double Xh;
		public double Yh;
		public CRect() 
		{
			(Xl, Yl, Xh, Yh) = (0, 0, 0, 0);
		}
		public CRect(double l, double t, double r, double b)
		{
			(Xl, Yl, Xh, Yh) = (l, t, r, b);
		}
	}
}
