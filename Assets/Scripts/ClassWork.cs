using System;

class ClassWork
{
    static double Power(double n, int x)
    {
        double result = 1;

        for (int i = 0; i < Math.Abs(x); i++)
        {
            result *= n;
        }

        if (x < 0)
            return 1 / result;

        return result;
    }

    static void Main()
    {
        Console.Write("Enter base number (n): ");
        double n = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter exponent (x): ");
        int x = Convert.ToInt32(Console.ReadLine());

        double power = Power(n, x);
        Console.WriteLine($"{n} raised to the power {x} is: {power}");
    }
}
