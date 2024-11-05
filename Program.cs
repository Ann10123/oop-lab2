class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть 1-ий дріб (чисельник та знаменник розділені пробілом): ");
        string[] input1 = Console.ReadLine().Trim().Split();
        MyFrac f1 = new MyFrac(long.Parse(input1[0]), long.Parse(input1[1]));

        Console.Write("Введіть 2-ий дріб (чисельник та знаменник розділені пробілом): ");
        string[] input2 = Console.ReadLine().Trim().Split();
        MyFrac f2 = new MyFrac(long.Parse(input2[0]), long.Parse(input2[1]));

        Console.Write("Введіть значення n для розрахунків: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nПерший дріб: {f1}");
        Console.WriteLine($"Другий дріб: {f2}");
        Console.WriteLine($"Скорочений перший дріб: {f1.ToStringWithIntPart()}");
        Console.WriteLine($"Скорочений другий дріб: {f2.ToStringWithIntPart()}");
        Console.WriteLine($"Перший дріб як десятковий: {f1.ToDouble()}");
        Console.WriteLine($"Другий дріб як десятковий: {f2.ToDouble()}");
        Console.WriteLine($"Результат обчислення для першого виразу: {MyFrac.CalcExpr1(n)}");
        Console.WriteLine($"Результат обчислення для другого виразу: {MyFrac.CalcExpr2(n)}");
    }
}