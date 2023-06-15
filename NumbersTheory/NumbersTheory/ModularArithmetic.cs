using System;
namespace NumbersTheory;
public static class ModularArithmetic
{
    private const int Size = (int)1E6 + 10;
    public static long Add(long firstNumber, long secondNumber, long modulesValue)
        => ((firstNumber % modulesValue) + (secondNumber % modulesValue)) % modulesValue;
    public static long Subtraction(long firstNumber, long secondNumber, long modulesValue)
        => ((firstNumber % modulesValue) - (secondNumber % modulesValue) + modulesValue) % modulesValue;
    public static long Multiplication(long firstNumber, long secondNumber, long modulesValue)
        => firstNumber % modulesValue * secondNumber % modulesValue % modulesValue;
    public static long Inverse(long number, long modulesValue)
    {
        if ((number & 1) is 0)
        {
            return default;
        }

        if (number % modulesValue is 0)
        {
            return default;
        }

        if (IsPrime(number) && modulesValue >= 2)
        {
            return FastPower(number, modulesValue - 2);
        }

        for (int i = 0; i < modulesValue; i++)
        {
            if (number * i % modulesValue is 1)
            {
                return i;
            }
        }
        return default;
    }

    private static bool IsPrime(long number)
    {
        if (number <= 1)
        {
            return false;
        }
        if (number == 2)
        {
            return true;
        }
        if (number % 2 == 0)
        {
            return false;
        }
        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    private static long FastPower(long number, long power)
    {
        if (power is 0)
        {
            return 1;
        }
        var sqrt = FastPower(number, power >> 1);
        return sqrt * sqrt * ((power & 1) is 1 ? number : 1);
    }
}

