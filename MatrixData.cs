using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp85
{
    partial class MyMatrix
    {
        private double[,] matrix;
        public MyMatrix(MyMatrix other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Another instance cannot be null.");
            }
            int rows = other.matrix.GetLength(0);
            int cols = other.matrix.GetLength(1);
            matrix = new double[rows, cols];
            Array.Copy(other.matrix, matrix, other.matrix.Length);
        }

        public MyMatrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }
            matrix = new double[array.GetLength(0), array.GetLength(1)];
            Array.Copy(array, matrix, array.Length);
        }

        // конструктор із зубчастого масиву (double[][])
        public MyMatrix(double[][] jaggedArray)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
            {
                throw new ArgumentException("A jagged array cannot be null or empty.");
            }
            int rowLength = jaggedArray[0].Length;

            // перевіряємо, чи всі рядки однакової довжини (прямокутний масив)
            if (jaggedArray.Any(row => row.Length != rowLength))
            {
                throw new ArgumentException("The array is not rectangular.");
            }

            matrix = new double[jaggedArray.Length, rowLength];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        // числа через пробіли/табуляції
        public MyMatrix(string[] rows)
        {
            if (rows == null || rows.Length == 0)
            {
                throw new ArgumentException("An array of strings cannot be null or empty.");
            }

            // розіб'ємо для визначення кількості колонок
            int columnCount = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            // чи всі мають однакову кі-сть елементів
            if (rows.Any(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length != columnCount))
            {
                throw new ArgumentException("The number of numbers in each line must be the same.");
            }

            matrix = new double[rows.Length, columnCount];

            for (int i = 0; i < rows.Length; i++)
            {
                var elements = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < elements.Length; j++)
                {
                    matrix[i, j] = double.Parse(elements[j]);
                }
            }
        }

        // конструктор з рядка, що містить пробіли, табуляції та переведення рядка
        public MyMatrix(string matrixString)
        {
            if (string.IsNullOrWhiteSpace(matrixString))
            {
                throw new ArgumentException("The string cannot be empty or null.");
            }

            // розбиваємо рядки
            var rows = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // для визначення кількості колонок
            int columnCount = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            // чи всі рядки мають однакову кількість елементів?
            if (rows.Any(row => row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length != columnCount))
            {
                throw new ArgumentException("The matrix must be rectangular.");
            }

            matrix = new double[rows.Length, columnCount];

            for (int i = 0; i < rows.Length; i++)
            {
                var elements = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < elements.Length; j++)
                {
                    matrix[i, j] = double.Parse(elements[j]);
                }
            }
        }
        public int Row
        {
            get { return matrix.GetLength(0); }
        }
        public int Column
        {
            get { return matrix.GetLength(1); }
        }

        // java-style getter
        public int GetRow()
        {
            return matrix.GetLength(0);
        }

        // java-style getter
        public int GetColumn()
        {
            return matrix.GetLength(1);
        }

        // індексатор
        public double this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Row || col < 0 || col >= Column)
                {
                    throw new IndexOutOfRangeException("Index outside matrix.");
                }
                return matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= Row || col < 0 || col >= Column)
                {
                    throw new IndexOutOfRangeException("Index outside matrix.");
                }
                matrix[row, col] = value;
            }
        }

        // java-style getter
        public double GetElement(int row, int col)
        {
            return this[row, col];
        }

        // java-style setter
        public void SetElement(int row, int col, double value)
        {
            this[row, col] = value;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    result += matrix[i, j] + (j < Column - 1 ? "\t" : "");
                }
                result += "\n";
            }
            return result;
        }

        public void PrintMatrix()
        {
            Console.WriteLine(ToString());
        }
    }
}