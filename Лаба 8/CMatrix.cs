using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Лаба_8
{
    public class CMatrix
    {
        private double[][] Matrix;
        private int Row;
        private int Column;
        public double this[int r, int c]
        {
            get => Matrix[r][c];
            set => Matrix[r][c] = value;
        }
        public double this[int r]
        {
            get => Matrix[r][0];
            set => Matrix[r][0] = value;
        }
        public int row
        {
            get => Row;
            set
            {
                if (value >= 1)
                {
                    Row = value;
                }
                else throw new Exception("Некорректный размер");
            }
        }
        public int column
        {
            get => Column;
            set
            {
                if (value >= 1)
                {
                    Column = value;
                }
                else throw new Exception("Некорректный размер");
            }
        }

        public CMatrix()
        {
            this.Row = 1;
            this.Column = 1;
            Array.Resize(ref Matrix, Row);
            for (int i = 0; i < row; i++)
            {
                Array.Resize(ref Matrix[i], Column);
            }
        }

        public CMatrix(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            Array.Resize(ref Matrix, Row);
            for (int i = 0; i < row; i++)
            {
                Array.Resize(ref Matrix[i], Column);
            }
        }

        public CMatrix(double[][] arr)
        {
            this.Row = arr.Length;
            this.Column = arr[0].Length;
            this.Matrix = arr;
        }

        public CMatrix(int row)
        {
            if (row == 3)
            {
                this.Row = row;
                this.Column = 1;
                Array.Resize(ref Matrix, this.Row);
                for (int i = 0; i < row; i++)
                {
                    Array.Resize(ref Matrix[i], 1);
                }
            }
            else throw new Exception("Некорректный размер");
        }

        public CMatrix(double i, double j, double k)
        {
            this.Row = 3;
            this.Column = 1;
            Array.Resize(ref Matrix, this.Row);
            for (int o = 0; o < row; o++)
            {
                Array.Resize(ref Matrix[o], 1);
            }
            this.Matrix[0][0] = i;
            this.Matrix[1][0] = j;
            this.Matrix[2][0] = k;
            
        }

        public CMatrix(CMatrix arr)
        {
            this.Row = arr.Row;
            this.Column = arr.Column;
            Array.Resize(ref Matrix, Row);
            for (int i = 0; i < row; i++)
            {
                Array.Resize(ref Matrix[i], Column);
            }
            if(arr.Column != 1)
            {
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Column; j++)
                    {
                        this.Matrix[i][j] = arr[i,j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.Row; i++)
                {
                    this.Matrix[i][0] = arr[i,0];
                }
            }
        }

        public void RandomCreate()
        {
            Random random = new Random();
            if (this.Column != 1)
            {
                CMatrix buf = new CMatrix(this.Row, this.Column);
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Column; j++)
                    {
                        buf[i,j] = random.Next(-50, 50);
                    }
                }
                Matrix = buf.Matrix;
            }
            else
            {
                CMatrix buf = new CMatrix(this.Row);
                for (int i = 0; i < this.Row; i++)
                {
                    buf[i, 0] = random.Next(-50, 50);
                }
                Matrix = buf.Matrix;
            }
        }

        public void ShowMatrix()
        {
            if(this.Column != 1)
            {
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Column; j++)
                    {
                        Console.Write(String.Format("{0,10}", this.Matrix[i][j]));
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < this.Row; i++)
                {
                    Console.Write(String.Format("{0,20}", this.Matrix[i][0]));
                }
            }
            Console.WriteLine();
        }

        public void ShowMatrixWPF(Label L)
        {
            if (this.Column != 1)
            {
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Column; j++)
                    {
                        L.Content += this.Matrix[i][j].ToString() + "          ";
                    }
                    L.Content += "\n";
                }
            }
            else
            {
                for (int i = 0; i < this.Row; i++)
                {
                    L.Content += this.Matrix[i][0].ToString() + "          ";
                }
            }
            L.Content += "\n";
        }

        public CMatrix Trans()
        {
            if(this.Column != 1)
            {
                CMatrix trans = new CMatrix(this.Row, this.Column);
                for (int i = 0; i < this.Column; i++)
                {
                    for (int j = 0; j < this.Row; j++)
                    {
                        trans[i, j] = Matrix[j][i];
                    }
                }
                return trans;
            }
            else
            {
                if(this.Row == 3)
                {
                    CMatrix trans = new CMatrix(this.Row);
                    double[] buf = { this.Matrix[0][0], this.Matrix[1][0], this.Matrix[2][0] };
                    Array.Resize(ref this.Matrix, 1);
                    trans.Matrix[0] = buf;
                    trans.Row = 1;
                    trans.row = 1;
                    trans.Column = 3;
                    trans.column = 3;
                    return trans;
                }
                else
                {
                    CMatrix trans = new CMatrix(this.Row);
                    double[][] buf = 
                    { 
                        new double[] {this.Matrix[0][0] },
                        new double[] { this.Matrix[1][0] },
                        new double[] { this.Matrix[2][0] } 
                    };
                    Array.Resize(ref this.Matrix, 3);
                    trans.Matrix = buf;
                    trans.Row = 3;
                    trans.row = 3;
                    trans.Column = 1;
                    trans.column = 1;
                    return trans;
                }

            }
        }

        public double[] GetRow(int r)
        {
            double[] arr = { };
            Array.Resize(ref arr, this.Column);
            for(int i=0; i < this.Column; i++)
            {
                arr[i]=this.Matrix[r][i];
            }
            return arr;
        }
        public CMatrix GetColumn(int c)
        {
            CMatrix arr = new CMatrix(this.Row,1);
            for (int i = 0; i < this.Row; i++)
            {
                arr[i,0] = this.Matrix[i][c];
            }
            return arr;
        }

        public void RedimMatrix(int r, int c)
        {
            double[][] buf = { };
            Array.Resize(ref buf, r);
            for (int i = 0; i < r; i++)
            {
                Array.Resize(ref buf[i], c);
            }
            this.Row = r;
            this.Column = c;
            this.Matrix = buf;
        }
        public void RedimMatrix(int r)
        {
            double[][] buf = { };
            Array.Resize(ref buf, r);
            for (int i = 0; i < r; i++)
            {
                Array.Resize(ref buf[i], 1);
            }
            this.Row = r;
            this.Column = 1;
            this.Matrix = buf;
        }
        public void RedimData(int r, int c)
        {
            double[][] buf = this.Matrix;
            Array.Resize(ref buf, r);
            for (int i = 0; i < r; i++)
            {
                Array.Resize(ref buf[i], c);
            }
            this.Row = r;
            this.Column = c;
            this.Matrix = buf;
        }
        public void RedimData(int r)
        {
            double[][] buf = this.Matrix;
            Array.Resize(ref buf, r);
            for (int i = 0; i < r; i++)
            {
                Array.Resize(ref buf[i], 1);
            }
            this.Row = r;
            this.Column = 1;
            this.Matrix = buf;
        }
        public double MaxElement()
        {
            double max = this.Matrix[0][0];
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    max = this.Matrix[i][j] > max ? this.Matrix[i][j] : max;
                }
            }
            return max;
        }
        public double MinElement()
        {
            double min = this.Matrix[0][0];
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    min = this.Matrix[i][j] < min ? this.Matrix[i][j] : min;
                }
            }
            return min;
        }
        public static CMatrix operator +(CMatrix arr1, CMatrix arr2)
        {
            if ((arr1.Column != arr2.Column) || (arr1.Row != arr2.Row))
            {
                throw new Exception("Для матриц с разным размером сложение не возможно!");
            }

            CMatrix arr3 = new CMatrix(arr1.Row, arr2.Column);

            for (var i = 0; i < arr1.Row; i++)
            {
                for (var j = 0; j < arr2.Column; j++)
                {
                    arr3[i,j] = arr1[i,j] + arr2[i,j];
                }
            }

            return arr3;
        }
        public static CMatrix operator +(CMatrix arr1, double num)
        {
            CMatrix arr3 = new CMatrix(arr1.Row, arr1.Column);

            for (var i = 0; i < arr1.Row; i++)
            {
                for (var j = 0; j < arr1.Column; j++)
                {
                    arr3[i, j] = arr1[i, j] + num;
                }
            }

            return arr3;
        }
        public static CMatrix operator -(CMatrix arr1, CMatrix arr2)
        {
            if ((arr1.Column != arr2.Column) || (arr1.Row != arr2.Row))
            {
                throw new Exception("Для матриц с разным размером вычитание не возможно!");
            }

            CMatrix arr3 = new CMatrix(arr1.Row, arr2.Column);

            for (var i = 0; i < arr1.Row; i++)
            {
                for (var j = 0; j < arr2.Column; j++)
                {
                    arr3[i,j] = arr1[i,j] - arr2[i,j];
                }
            }

            return arr3;
        }

        public static CMatrix operator -(CMatrix arr1, double num)
        {
            CMatrix arr3 = new CMatrix(arr1.Row, arr1.Column);

            for (var i = 0; i < arr1.Row; i++)
            {
                for (var j = 0; j < arr1.Column; j++)
                {
                    arr3[i, j] = arr1[i, j] - num;
                }
            }

            return arr3;
        }
        public static CMatrix operator *(CMatrix arr1, CMatrix arr2)
        {
            if (arr1.Column != arr2.Row)
            {
                throw new Exception("Для матриц с разным размером умножение не возможно!");
            }

            CMatrix arr3 = new CMatrix(arr1.Row, arr2.Column);

            for (var i = 0; i < arr1.Row; i++)
            {
                for (var j = 0; j < arr2.Column; j++)
                {
                    arr3[i, j] = 0;

                    for (var k = 0; k < arr1.Column; k++)
                    {
                        arr3[i, j] += arr1[i, k] * arr2[k, j];
                    }
                }
            }

            return arr3;
        }

        public static CMatrix operator *(CMatrix arr1, double num)
        {
            CMatrix arr3 = new CMatrix(arr1.Row, arr1.Column);

            for (var i = 0; i < arr1.Row; i++)
            {
                for (var j = 0; j < arr1.Column; j++)
                {
                    arr3[i, j] = arr1[i, j] * num;
                }
            }

            return arr3;
        }
        public static CMatrix SpaceToWindow(CRect W, CRect S)
        {
            CMatrix M = new CMatrix(3, 3);
            double kx = (double)(W.Xh - W.Xl ) / (S.Xh - S.Xl);
            double ky = (double)(W.Yh - W.Yl ) / (S.Yh - S.Yl);
            M[0, 0] = kx;
            M[1, 0] = 0;
            M[2, 0] = 0;

            M[0, 1] = 0;
            M[1, 1] = -ky;
            M[2, 1] = 0;

            M[0, 2] = (double)W.Xl - kx * S.Xl;
            M[1, 2] = (double)W.Yh + ky * S.Yl;
            M[2, 2] = 1;
            return M;
        }

        public static CMatrix getConverterWorldToView(CMatrix View)
        {
            View[1, 0] = ((View[1, 0] % 360.0) / 180.0) * Math.PI;
            View[2, 0] = ((View[2, 0] % 360.0) / 180.0) * Math.PI;

            CMatrix Convert = new CMatrix(4, 4);
            Convert[0, 0] = -Math.Sin(View[1, 0]);
            Convert[0, 1] = Math.Cos(View[1, 0]);

            Convert[1, 0] = -Math.Cos(View[2, 0]) * Math.Cos(View[1, 0]);
            Convert[1, 1] = -Math.Cos(View[2, 0]) * Math.Sin(View[1, 0]);
            Convert[1, 2] = Math.Sin(View[2, 0]);

            Convert[2, 0] = Math.Sin(View[2, 0]) * Math.Cos(View[1, 0]);
            Convert[2, 1] = Math.Sin(View[2, 0]) * Math.Sin(View[1, 0]);
            Convert[2, 2] = Math.Cos(View[2, 0]);
            Convert[2, 3] = View[0, 0];

            Convert[3, 3] = 1;

            return Convert;
        }
    }

    static class CMatrixMethod
    {
        public static CMatrix VectorMult(CMatrix V1, CMatrix V2)
        {
            if (V1.column == 1 && V2.column == 1)
            {
                return new CMatrix((V1[1, 0] * V2[2, 0] - V1[2, 0] * V2[1, 0]), (V1[2, 0] * V2[0, 0] - V1[0, 0] * V2[2, 0]), (V1[0, 0] * V2[1, 0] - V1[1, 0] * V2[0, 0]));
            }
            else throw new Exception("Объект не является вектором");
        }
        public static double ScalarMult(CMatrix V1, CMatrix V2)
        {
            if (V1.column == 1 && V2.column == 1)
            {
                return (V1[0, 0] * V2[0, 0]) + (V1[1, 0] * V2[1, 0]) + (V1[2, 0] * V2[2, 0]);
            }
            else throw new Exception("Объект не является вектором");
        }
        public static double CosV1V2(CMatrix V1, CMatrix V2)
        {
            if (V1.column == 1 && V2.column == 1)
            {
                return ScalarMult(V1, V2)/(ModVec(V1)*ModVec(V2));
            }
            else throw new Exception("Объект не является вектором");
        }
        public static double ModVec(CMatrix V1)
        {
            if (V1.column == 1)
            {
                return Math.Sqrt(Math.Pow(V1[0, 0], 2) + Math.Pow(V1[1, 0], 2) + Math.Pow(V1[2, 0], 2));
            }
            else throw new Exception("Объект не является вектором");
        }
        public static CMatrix SphereToCart(CMatrix PView)
        {
            if (PView.column == 1)
            {
                double r = PView[0,0], phi = (PView[1,0] / 180.0) * Math.PI, theta = (PView[2,0] / 180.0) * Math.PI;
                CMatrix result= new CMatrix(3,1);
                result[0,0] = r * Math.Sin(theta) * Math.Cos(phi);
                result[1,0] = r * Math.Sin(theta) * Math.Sin(phi);
                result[2,0] = r * Math.Cos(theta);
                return result;
            }
            else throw new Exception("Объект не подходит");
        }
    }
}
