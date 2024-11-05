using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp85
{
    partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            double[,] result = new double[a.Row, a.Column];

            if (a.Row != b.Row || a.Column != b.Column)
            {
                throw new InvalidOperationException("Matrices must be the same size for addition.");
            }

            for (int i = 0; i < a.Row; i++)
            {
                for (int j = 0; j < a.Column; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return new MyMatrix(result);
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Column != b.Row)
            {
                throw new InvalidOperationException("The number of columns of the first matrix must be equal to the number of rows of the second matrix for multiplication.");
            }

            double[,] result = new double[a.Row, b.Column];

            for (int i = 0; i < a.Row; i++)
            {
                for (int j = 0; j < b.Column; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.Column; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return new MyMatrix(result);
        }

        // приватний метод для отримання транспонованого double[,]
        private double[,] GetTransponedArray()
        {
            double[,] transposed = new double[Column, Row];

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return transposed;
        }

        // отримання нової транспонованої копії mymatrix
        public MyMatrix GetTransponedCopy()
        {
            double[,] transposedArray = GetTransponedArray();
            return new MyMatrix(transposedArray);
        }

        // транспонування поточної матриці
        public void TransponeMe()
        {
            matrix = GetTransponedArray();
        }
        public double CalcDeterminant()
        {
            if (Row != Column)
            {
                throw new InvalidOperationException("Матриця не квадратна, визначник знайти неможливо!");
            }
            return CalcDeterminantRecursive((double[,])matrix.Clone());
        }
        private double CalcDeterminantRecursive(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1)
            {
                return matrix[0, 0];
            }
            if (n == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double determinant = 0;
            for (int col = 0; col < n; col++)
            {
                double[,] minor = GetMinor(matrix, 0, col);
                int temp;
                if (col % 2 == 0)
                {
                    temp = 1;
                }
                else
                {
                    temp = -1;
                }

                determinant += temp * matrix[0, col] * CalcDeterminantRecursive(minor);
            }
            return determinant;
        }
        private double[,] GetMinor(double[,] matrix, int row, int col)
        {
            int n = matrix.GetLength(0);
            double[,] minor = new double[n - 1, n - 1];
            for (int i = 0, mi = 0; i < n; i++)
            {
                if (i == row) continue;
                for (int j = 0, mj = 0; j < n; j++)
                {
                    if (j == col) continue;
                    minor[mi, mj] = matrix[i, j];
                    mj++;
                }
                mi++;
            }
            return minor;
        }
    }
}