namespace NumbersTheory;
public static class BinaryExponentiation
{
    public static int Calculate(int number, int power, int result)
    {
            if (power <= 0)
            {
                return result;
            }
            if ((power & 1) is 1)
            {
                result *= number;
            }
            number *= number;
            power >>= 1;
            return Calculate(number, power, result);
    }

    public static int Calculate(int number, int power)
    {
        if (power is 0)
        {
            return 1;
        }
        var sqrt = Calculate(number, power >> 1);
        return sqrt * sqrt * ((power & 1) is 1 ? number : 1);
    }
}
