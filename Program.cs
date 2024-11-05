namespace ConsoleApp85
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Console.WriteLine("Елементи 1-ої матриці:");
                MyMatrix matrix_1 = Input();
                Console.WriteLine("Елементи 2-ої матриці:");
                MyMatrix matrix_2 = Input();
                Operations(matrix_1, matrix_2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Operations(MyMatrix matrix_1, MyMatrix matrix_2)
        {
            MyMatrix matrix_11 = matrix_1;
            MyMatrix matrix_12 = matrix_2;
            Console.WriteLine("1-ша транспонована матриця:");
            matrix_1.TransponeMe();
            matrix_1.PrintMatrix();
            Console.WriteLine("2-га транспонована матриця:");
            matrix_2.TransponeMe();
            matrix_2.PrintMatrix();
            Console.WriteLine("Множення матриць: ");
            (matrix_11 * matrix_12).PrintMatrix();
            Console.WriteLine("Сума матриць: ");
            (matrix_11 + matrix_12).PrintMatrix();
            Console.Write("Визначник 1-ої матриці: ");
            double determinant1 = matrix_1.CalcDeterminant();
            Console.Write(determinant1);
            Console.WriteLine();
            Console.Write("Визначник 2-ої матриці: ");
            double determinant2 = matrix_2.CalcDeterminant();
            Console.Write(determinant2);
            Console.WriteLine();
        }
        static MyMatrix Input()
        {
            Console.WriteLine("2 - ввести самостійно двовимірний масив");
            Console.WriteLine("3 - ввести зубчастий масив");
            Console.WriteLine("4 - ввести масив рядків");
            Console.WriteLine("5 - ввести матрицю як один рядок");
            MyMatrix originalMatrix;
            int choice = int.Parse(Console.ReadLine() ?? "0");

            switch (choice)
            {
                case 2:
                    Console.Write("К-сть рядків та стовпчиків: ");
                    string[] data2 = Console.ReadLine().Trim().Split();
                    int rows2 = int.Parse(data2[0]);
                    int cols2 = int.Parse(data2[1]);

                    double[,] elements2 = new double[rows2, cols2];
                    Console.WriteLine("Введіть елементи матриці: ");
                    for (int i = 0; i < rows2; i++)
                    {
                        for (int j = 0; j < cols2; j++)
                        {
                            elements2[i, j] = double.Parse(Console.ReadLine());
                        }
                    }
                    originalMatrix = new MyMatrix(elements2);
                    return originalMatrix;

                case 3:
                    Console.Write("К-сть рядків: ");
                    int rows3 = int.Parse(Console.ReadLine());

                    double[][] jaggedArray = new double[rows3][];
                    for (int i = 0; i < rows3; i++)
                    {
                        Console.Write($"К-сть стовчиків у рядку {i + 1}: ");
                        int cols3 = int.Parse(Console.ReadLine());
                        jaggedArray[i] = new double[cols3];

                        Console.WriteLine($"Введіть елементи рядку {i + 1}: ");
                        for (int j = 0; j < cols3; j++)
                        {
                            jaggedArray[i][j] = double.Parse(Console.ReadLine());
                        }
                    }
                    originalMatrix = new MyMatrix(jaggedArray);
                    return originalMatrix;

                case 4:
                    Console.Write("К-сть рядків: ");
                    int rows4 = int.Parse(Console.ReadLine());

                    string[] stringArray = new string[rows4];
                    Console.WriteLine("Введіть рядки значень: ");
                    for (int i = 0; i < rows4; i++)
                    {
                        stringArray[i] = Console.ReadLine() ?? string.Empty;
                    }
                    originalMatrix = new MyMatrix(stringArray);
                    return originalMatrix;

                case 5:
                    Console.WriteLine("Введіть елементи матриці");
                    string input = Console.ReadLine();
                    string[] elementsString = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    int rows5 = int.Parse(elementsString[0]);
                    int cols5 = int.Parse(elementsString[1]);
                    double[,] elements5 = new double[rows5, cols5];

                    for (int i = 0; i < rows5; i++)
                    {
                        for (int j = 0; j < cols5; j++)
                        {
                            elements5[i, j] = double.Parse(elementsString[(i * cols5) + j + 2]); // +2, щоб пропустити розміри
                        }
                    }
                    originalMatrix = new MyMatrix(elements5);
                    return originalMatrix;
                default:
                    double[,] elements6 = { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };
                    originalMatrix = new MyMatrix(elements6);
                    return originalMatrix;
            }
        }
    }
}
