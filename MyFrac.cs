using System;

class MyFrac
{
    public long Nom { get; set; } 
    public long Denom { get; set; } 
    public MyFrac(long nom, long denom)
    {
        if (denom == 0)
        {
            throw new ArgumentException("Знаменник не може бути 0!");
        }
        Nom = nom;
        Denom = denom;
        Normalize();
    }
    private void Normalize()
    {
        if (Denom < 0)
        {
            Nom = -Nom;
            Denom = -Denom;
        }
        long gcd = GCD(Math.Abs(Nom), Math.Abs(Denom));
        if (gcd > 1)
        {
            Nom /= gcd;
            Denom /= gcd;
        }
    }

    private static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        return ($"{Nom}/{ Denom}");
    }
    public string ToStringWithIntPart()
    {
        if (Math.Abs(Nom) < Denom)
        {
            return ToString();
        }
        long wholePart = Nom / Denom;
        long remainder = Math.Abs(Nom % Denom);

        return remainder == 0
            ? $"{wholePart}"
            : $"{wholePart}+({remainder}/{Denom})";
    }

    public double ToDouble() => (double)Nom / Denom;

    public static MyFrac operator +(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.Nom * f2.Denom + f2.Nom * f1.Denom, f1.Denom * f2.Denom);
    }
    public static MyFrac operator -(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.Nom * f2.Denom - f2.Nom * f1.Denom, f1.Denom * f2.Denom);
    }
    public static MyFrac operator *(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.Nom * f2.Nom, f1.Denom * f2.Denom);
    }
    public static MyFrac operator /(MyFrac f1, MyFrac f2)
    {
        if (f2.Nom == 0)
        {
            throw new DivideByZeroException("Ділити на 0 не можна!");
        }
        return new MyFrac(f1.Nom * f2.Denom, f1.Denom * f2.Nom);
    }
    public static MyFrac CalcExpr1(int n)
    {
        MyFrac result = new MyFrac(0, 1);
        for (int i = 1; i * (i + 1) <= n * (n + 1); i++)
        {
            MyFrac add = new MyFrac(1, i * (i + 1));
            result += add;
        }
        return result;
    }

    public static MyFrac CalcExpr2(int n)
    {
        MyFrac result = new MyFrac(1, 1);
        for (long i = 2; i <= n; i++)
        {
            MyFrac term = new MyFrac(i * i - 1, i * i);
            result *= term;
        }
        return result;
    }
}



