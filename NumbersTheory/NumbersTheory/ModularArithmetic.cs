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
        if (GCD(number, modulesValue) is not 1)
        {
            return default;
        }
        if (number % modulesValue is 0)
        {
            return default;
        }

        if (IsPrime(number) && modulesValue >= 2)
        {
            return FastPower(number, modulesValue - 2, modulesValue);
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


    private static long FastPower(long baseValue, long exponent, long modulus, long result = 1)
    {
        if (modulus is 1)
        {
            return 0;
        }
        if (exponent <= 0)
        {
            if (result < 0)
            {
                return (result + modulus) % modulus;
            }
            return result;
        }
        if ((exponent & 1) is 1)
        {
            result = (result * baseValue) % modulus;
        }
        baseValue = (baseValue * baseValue) % modulus;
        exponent >>= 1;
        return FastPower(baseValue, exponent, modulus, result);
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
    

    public static long Factorial(long number, long modules)
    {
        var result = 0L + 1;
        for (int i = 2; i <= number; i++)
        {
            result = (result * i) % modules;
        }
        return result;
    }

    public static long NPR(long number, long r, long modules)
    {
        ///1 2 3 4
        ///1 2
        ///1 2 3 4
        var result = 0L + 1;
        for (long i = number - r + 1; i <= number; i++)
        {
            result = (result * i) % modules;
        }
        return result;
    }

    public static long NCR(long number, long r, long modulus)
    {
        if (number < 0 || r < 0 || r > number)
        {
            throw new ArgumentException("Invalid values for n and r.");
        }
        long numerator = Factorial(number, modulus);
        long denominator = (Factorial(r, modulus) * Factorial(number - r, modulus)) % modulus;
        long modularInverse = Inverse(denominator, modulus);
        long result = (numerator * modularInverse) % modulus;
        return result;
    }
    public static Tuple<int, int, int> BezoutTheorem(int divided, int divisor)
    {
        if (divisor is 0)
        {
            return Tuple.Create(1, 0, divided);
        }
        var (x1, y1, d) = BezoutTheorem(divisor, divided % divisor);
        var x = y1;
        var y = x1 - y1 * (divided / divisor);
        return Tuple.Create(x, y, d);
    }

    private static long GCD(long divided, long divisor)
    {
        if (divisor is 0)
        {
            return divided;
        }
        var reminder = divided % divisor;
        return GCD(divisor, reminder);
    }
}

