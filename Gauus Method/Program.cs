using System;
using static System.Console;
using static System.Math;

namespace Slar_Gauss_v_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SLAR_Gauss m = new SLAR_Gauss();
            m.SetParametes();
            m.DoTriangle();
            m.Revers();
            m.OutputNewMatrix();
            ReadKey();
        }
    }

    class SLAR_Gauss
    {
        static int n = int.Parse(ReadLine());
        double[,] Matrix = new double[n, n + 1];//{ { 10, -7, 0, 7 }, { -3, 2, 6, 4 }, { 5, -1, 5, 6 } }; Рішення це 1 -1 0
        double[] Temporary = new double[n + 1];
        double[] Result = new double[n];

        double MaxElement = 0;
        double koef;

        int I = 1;
        int J = 0;
        int MaxI;
        int Count = 1;

        public void SetParametes()
        {
            WriteLine("Enter the parameters");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    WriteLine("e[{0}][{1}]", i, j);
                    Matrix[i, j] = double.Parse(ReadLine());
                }
            }
        }

        public void SearchMaxElement()
        {
            MaxElement = Matrix[I - 1, J];
            for (int i = I - 1; i < n; i++)
            {
                if (Abs(MaxElement) < Abs(Matrix[i, J]))
                {
                    MaxI = i;
                    MaxElement = Matrix[i, J];
                }
            }
        }

        public void Change()
        {
            for (int j = J; j < n + 1; j++)
            {
                Temporary[j] = Matrix[I - 1, j];
                Matrix[I - 1, j] = Matrix[MaxI, j];
                Matrix[MaxI, j] = Temporary[j];
            }
        }
        public void DoTriangle()
        {
            while (Count < n + 1)
            {
                SearchMaxElement();
                Change();
                for (int i = I; i < n; i++)
                {
                    koef = Matrix[I, J] / Matrix[J, J];
                    for (int j = J; j < n + 1; j++)
                    {
                        Matrix[i, j] = Matrix[i, j] - Matrix[J, j] * koef;
                    }
                    I++;
                }
                Count++;
                J++;
                I = J + 1;
            }
        }
        public void OutputNewMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    Write(Matrix[i, j]);
                    Write("\t");
                }
                WriteLine("\n");
            }
            for (int j = 0; j < n; j++)
            {
                Write("x{0}: ", j);
                WriteLine(Round(Result[j], 6));
            }

        }

        public void Revers()
        {
            for (int i = n - 1; i >= 0; i--)
            {
                double summ = 0;
                for (int j = i + 1; j < n; j++)
                {
                    summ += Matrix[i, j] * Result[j];
                }
                summ = Matrix[i, n] - summ;
                Result[i] = summ / Matrix[i, i];
            }
        }
    }
}
