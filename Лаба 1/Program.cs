using System;

namespace Лаба_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double[][] arr =
                {
                    new double[] {2,8,5},
                    new double[] {1,10,5},
                    new double[] {9,9,3}
                };
                double[][] arr2 =
                {
                    new double[] {5,6,6},
                    new double[] {2,8,2},
                    new double[] {2,6,3}
                };
                CMatrix matrix1 = new CMatrix(arr);
                CMatrix matrix2 = new CMatrix(arr2);
                CMatrix V1 = new CMatrix(8,7,2);
                CMatrix V2 = new CMatrix(5,3,4);
                Console.WriteLine("A:");
                matrix1.ShowMatrix();
                Console.WriteLine("B:");
                matrix2.ShowMatrix();
                Console.WriteLine("V1:");
                V1.ShowMatrix();
                Console.WriteLine("V2:");
                V2.ShowMatrix();
                Console.WriteLine("C1:");
                (matrix1 + matrix2).ShowMatrix();
                Console.WriteLine("C2:");
                (matrix1 * matrix2).ShowMatrix();
                Console.WriteLine("D:");
                (matrix1 * V1).ShowMatrix();
                Console.WriteLine("q:");
                CMatrix tr = V1.Trans();
                (tr * V2).ShowMatrix();
                Console.WriteLine("p:");
                (tr * matrix1 * V2).ShowMatrix();




                CMatrix v1 = new CMatrix(8, 7, 2);
                CMatrix v2 = new CMatrix(5, 3, 4);
                CMatrix PView = new CMatrix(8, 7, 2);
                Console.WriteLine("VectorMult:");
                CMatrixMethod.VectorMult(v1, v2).ShowMatrix();
                Console.WriteLine("ScalarMult: {0}", CMatrixMethod.ScalarMult(v1, v2));
                Console.WriteLine("ModVec: {0}", CMatrixMethod.ModVec(v1));
                Console.WriteLine("CosV1V2: {0}", CMatrixMethod.CosV1V2(v1, v2));
                Console.WriteLine("SphereToCart:");
                CMatrixMethod.SphereToCart(PView).ShowMatrix();




            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
