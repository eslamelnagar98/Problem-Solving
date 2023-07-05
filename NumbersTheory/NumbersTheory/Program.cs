using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersTheory
{
    internal class Program
    {
        private static HashSet<ulong> _tPrimeNumbers = new();
        private static Dictionary<int, int> _primeNumbersDictionary = new();
        static void Main(string[] args)
        {
            //Console.WriteLine(ModularArithmetic.Inverse(3, 1));
            //Console.WriteLine(BinaryExponentiation.Calculate(3, 10));
            //AlmostPrimeVJudge();
            //TPrimesVJudge();
            //TenThousandFirstprime();
            //IntegerFactorization();
            //NoldbachproblemVJudge();
            //LargestPrimefactorVJudge();
            //SummationOfPrimesVJudge();
            //NumberIntoSequenceVJudge();
            //MinOperationsLeetCode(new int[10]);
            //CalculateModules();
            //TheEternalImmortalityCodeForces();
            //ModularExponentiationCodeForces();
            //BeautifulDivisorsCodeForces();
            //SmallestMultiplevJudge();
            //StringLCMVJudge();
            //Console.WriteLine(ModularArithmetic.Inverse(17, 13));
            //.WriteLine(ModularArithmetic.Factorial(1000, 1000000007));
            //Console.WriteLine(ModularArithmetic.NCR(10, 3, 1000000007));
            //Console.WriteLine(ModularArithmetic.Multiplication(7, 10, 6));
            (var x, var y, var gcd) = ModularArithmetic.BezoutTheorem(16, 10);
            Console.WriteLine($"{x},{y},{gcd}");
        }

        private static void StringLCMVJudge()
        {
            var testCases = short.Parse(Console.ReadLine());
            while (testCases-- is not 0)
            {
                var firstWord = Console.ReadLine();
                var secondWord = Console.ReadLine();
                var firstWordLength = firstWord.Length;
                var secondWordLength = secondWord.Length;
                var lcm = firstWordLength / GCD(firstWordLength, secondWordLength) * secondWordLength;
                var firstWordstringBuilder = new StringBuilder(firstWord);
                var secondWordstringBuilder = new StringBuilder(secondWord);
                var firstWordReminder = (lcm - firstWordLength) is not 0 ? (lcm - firstWordLength) / firstWordLength : 0;
                var secondWordReminder = (lcm - secondWordLength) is not 0 ? (lcm - secondWordLength) / secondWordLength : 0;
                for (int i = 0; i < firstWordReminder; i++)
                {
                    firstWordstringBuilder.Append(firstWord);
                }
                for (int i = 0; i < secondWordReminder; i++)
                {
                    secondWordstringBuilder.Append(secondWord);
                }

                Console.WriteLine(firstWordstringBuilder.Equals(secondWordstringBuilder) ? firstWordstringBuilder : "-1");
            }
        }

        private static void SmallestMultiplevJudge()
        {
            var testCases = short.Parse(Console.ReadLine());
            while (testCases-- is not 0)
            {
                var length = short.Parse(Console.ReadLine());
                var numberList = Enumerable.Range(2, length - 1).ToList();
                var lcm = numberList.Aggregate(1, LCM);
                Console.WriteLine(lcm);
            }
        }

        private static int LCM(int firstNumber, int secondNumber) => firstNumber / GCD(firstNumber, secondNumber) * secondNumber;
        private static void BeautifulDivisorsCodeForces()
        {
            var number = int.Parse(Console.ReadLine());
            var divisors = GetAllDivisors(number);
            var powers = GetAllIntPowers();
            foreach (var divisor in divisors)
            {
                for (int i = 1; i < powers.Count(); i++)
                {
                    if ((powers[i] - 1) * powers[i - 1] == divisor)
                    {
                        Console.WriteLine(divisor);
                        return;
                    }
                }
            }

        }

        //private static IEnumerable<int> GetAllDivisors(int number)
        //{
        //    var boundary = (int)Math.Floor(Math.Sqrt(number));
        //    for (int i = 1; i <= boundary; i++)
        //    {
        //        if (number % i == 0)
        //        {
        //            yield return i;
        //            if (i * i != number)
        //            {
        //                yield return number / i;
        //            }
        //        }

        //    }
        //}

        private static List<int> GetAllDivisors(int number)
        {
            var highList = new List<int>();
            var lowList = new List<int>();
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 1; i <= boundary; i++)
            {
                if (number % i == 0)
                {
                    lowList.Add(i);
                    if (i * i != number)
                    {
                        highList.Add(number / i);
                    }
                }

            }
            highList.AddRange(lowList.OrderByDescending(number => number).ToList());
            return highList;
        }

        private static List<int> GetAllIntPowers()
        {
            var list = new List<int>();
            for (int i = 0; i < 17; i++)
            {
                list.Add((int)Math.Pow(2, i));
            }
            return list;
        }

        private static void ModularExponentiationCodeForces()
        {
            var power = int.Parse(Console.ReadLine());
            var modules = int.Parse(Console.ReadLine());
            if (power <= 27)
            {
                Console.WriteLine(modules % BinaryExponentiation.Calculate(2, power, 1));
                return;
            }
            Console.WriteLine(modules);
        }

        private static void TheEternalImmortalityCodeForces()
        {
            (var first, var last) = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToTuple();
            var result = 1E1 / 10;
            var reminder = last - first;
            if (reminder >= 10)
            {
                Console.WriteLine("0");
                return;
            }
            for (long i = first + 1; i <= last; i++)
            {
                result *= (i % 10);
                result %= 10;
            }
            Console.WriteLine(result);
        }



        private static void CalculateModules()
        {
            var number = int.Parse(Console.ReadLine());
            var modules = int.Parse(Console.ReadLine());
            var stringBuilder = new StringBuilder();
            var innerStringBuilder = new StringBuilder();
            for (int i = 0; i < modules; i++)
            {
                innerStringBuilder.Append($"{i} %  {modules}===>{i % modules}");
                innerStringBuilder.AppendLine();
            }
            stringBuilder.Append(innerStringBuilder);
            var length = number / modules;
            var reminder = number % modules;
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(innerStringBuilder);
            }
            for (int i = 0; i < reminder; i++)
            {
                stringBuilder.Append($"{i} % {modules}===>{i % modules}");
                stringBuilder.AppendLine();
            }
            Console.WriteLine(stringBuilder);
        }
        private static int MinOperationsLeetCode(int[] nums)
        {
            var gcd = default(int);
            var numberOfOnes = default(int);
            foreach (var num in nums)
            {
                gcd = GCD(gcd, num);
                numberOfOnes += num is 1 ? 1 : 0;
            }

            if (gcd is not 1)
            {
                return -1;
            }

            if (numberOfOnes is not 0)
            {
                return nums.Length - numberOfOnes;
            }
            var minimum = (int)1E6;
            for (int i = 0; i < nums.Length; i++)
            {
                var arrayElement = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    arrayElement = GCD(arrayElement, nums[j]);
                    if (arrayElement is 1)
                    {
                        minimum = Math.Min(minimum, j - i);
                        break;
                    }
                }
            }

            return minimum + nums.Length - 1;
        }

        private static int GCD(int divided, int divisor)
        {
            if (divisor is 0)
            {
                return divided;
            }
            var reminder = divided % divisor;
            return GCD(divisor, reminder);
        }

        private static void NumberIntoSequenceVJudge()
        {
            int testCases = int.Parse(Console.ReadLine());
            var stringBuilder = new StringBuilder();
            List<ulong> result;
            while (testCases-- is not 0)
            {
                var input = ulong.Parse(Console.ReadLine());
                var sortedFactorizationList = FactorizationList(input)
                    .OrderByDescending(factorize => factorize.Value);
                result = new List<ulong>();
                var maximumElement = sortedFactorizationList.FirstOrDefault();
                for (int i = 1; i < maximumElement.Value; i++)
                {
                    result.Add(maximumElement.Key);
                    input /= maximumElement.Key;
                }
                result.Add(input);
                stringBuilder.AppendLine(maximumElement.Value.ToString());
                stringBuilder.AppendLine(string.Join(" ", result));
            }
            Console.WriteLine(stringBuilder);
        }
        private static BitArray Sieve()
        {
            const int length = 10000001;
            var primeSieve = new BitArray(length, false);
            primeSieve[0] = true;
            primeSieve[1] = true;
            for (int i = 2; i * i < primeSieve.Length; i++)
            {
                if (!primeSieve[i])
                {
                    for (int j = i + i; j < primeSieve.Length; j += i)
                    {
                        primeSieve[j] = true;
                    }
                }
            }
            return primeSieve;
        }


        private static void SummationOfPrimesVJudge()
        {
            var primeSieve = Sieve();
            var testCases = short.Parse(Console.ReadLine());
            while (testCases-- is not 0)
            {
                var primesSummitionArray = new long[1_000_000_1];
                var length = int.Parse(Console.ReadLine());
                primesSummitionArray[0] = 0;
                primesSummitionArray[1] = 0;
                for (int i = 2; i <= length; i++)
                {
                    primesSummitionArray[i] = primesSummitionArray[i - 1] + (!primeSieve[i] ? i : 0);
                }

                Console.WriteLine(primesSummitionArray[length]);
            }
        }

        private static int SumPrimes(int length)
        {
            var sum = default(int);
            if (length >= 2)
            {
                sum += 2;
            }
            for (int i = 3; i <= 1_000_000; i += 2)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }

            return sum;
        }

        private static void LargestPrimefactorVJudge()
        {
            var testCases = short.Parse(Console.ReadLine());
            while (testCases-- is not 0)
            {
                var number = ulong.Parse(Console.ReadLine());
                var factorizationList = FactorizationList(number);
                Console.WriteLine(factorizationList.Select(s => s.Key).Max());
            }
        }

        private static void NoldbachproblemVJudge()
        {
            var line = Console.ReadLine().Split(' ').Select(short.Parse);
            var length = line.First();
            var count = line.Last();
            var primes = GeneratePrimes(length).ToList();
            var counter = default(short);
            for (int i = 0; i < primes.Count() - 1; i++)
            {
                if (primes[i] + primes[i + 1] + 1 <= length)
                {
                    if (IsPrime(primes[i] + primes[i + 1] + 1))
                    {
                        counter++;
                    }
                }
            }
            if (counter >= count)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        private static IEnumerable<short> GeneratePrimes(short number)
        {
            for (short i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    yield return i;
                }
            }
        }
        private static void IntegerFactorization()
        {
            var line = default(ulong);
            while ((line = Console.ReadLine()
                .Split(' ')
                .Select(ulong.Parse)
                .FirstOrDefault()) is not default(ulong))
            {
                var factorizationList = FactorizationList(line);
                foreach (var factorize in factorizationList)
                {
                    Console.Write($"{factorize.Key}^{factorize.Value} ");
                }

                Console.WriteLine();
            }
        }

        private static IEnumerable<KeyValuePair<ulong, int>> FactorizationList(ulong number)
        {
            ulong one = 1;
            ulong two = 2;
            for (ulong i = 2; i * i <= number; i += (i & 1) == 0 ? one : two)
            {
                var count = default(int);
                if (number % i == 0)
                {
                    while (number % i == 0)
                    {
                        count++;
                        number /= i;
                    }
                    yield return new KeyValuePair<ulong, int>(i, count);
                }
            }

            if (number > 1)
            {
                yield return new KeyValuePair<ulong, int>(number, 1);
            }
        }

        private static void TenThousandFirstprime()
        {
            FillPrimeNumbersDictionary();
            var testCases = short.Parse(Console.ReadLine());

            while (testCases-- is not 0)
            {
                var index = int.Parse(Console.ReadLine());
                _primeNumbersDictionary.TryGetValue(index, out var prime);
                Console.WriteLine(prime);

            }
        }

        private static void FillPrimeNumbersDictionary()
        {
            var index = default(int);
            for (int i = 2; i < 1_000_000; i++)
            {
                if (IsPrime(i))
                {
                    index++;
                    _primeNumbersDictionary.TryAdd(index, i);
                }
            }
        }

        private static void TPrimesVJudge()
        {
            GenerateTPrimeNumbers();
            var length = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .First();

            var numbersList = Console.ReadLine()
                .Split(' ')
                .Select(ulong.Parse)
                .ToList();

            for (int i = 0; i < length; i++)
            {
                _tPrimeNumbers.TryGetValue(numbersList[i], out var number);
                if (number is not default(long))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        private static void GenerateTPrimeNumbers()
        {
            for (int i = 2; i < 1_000_000; i++)
            {
                if (IsPrime(i))
                {
                    _tPrimeNumbers.Add((ulong)i * (ulong)i);
                }
            }
        }

        private static void AlmostPrimeVJudge()
        {
            var number = Console
                .ReadLine()
                .Trim()
                .Split(' ')
                .Select(int.Parse)
                .FirstOrDefault();
            var numberCounter = default(int);
            for (int i = 6; i <= number; i++)
            {
                if (PrimeFactorization(i) == 2)
                {
                    numberCounter++;
                }
                //var count = Divisors(i);
                //if (count == 2)
                //{
                //    numberCounter++;
                //}

            }
            Console.WriteLine(numberCounter);
        }
        private static bool IsPrime(int number)
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
        private static int Divisors(int number)
        {
            var count = 0;
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= boundary; i++)
            {
                if (number % i == 0)
                {
                    if (IsPrime(i))
                    {
                        count++;
                    }
                    if (i != number / i)
                    {
                        if (IsPrime(number / i))
                        {
                            count++;
                        }
                    }

                }
            }
            return count;
        }

        private static int PrimeFactorization(int number)
        {
            var count = default(int);
            for (int i = 2; i <= number / i; ++i)
            {
                if (number % i != 0)
                {
                    continue;
                }
                count++;
                while (number % i == 0)
                {
                    number /= i;
                }
            }
            if (number != 1)
            {
                count++;
            }
            return count;
        }
    }

    public static class Extensions
    {
        public static Tuple<long, long> ToTuple(this IEnumerable<long> inputList)
            => Tuple.Create(inputList.FirstOrDefault(), inputList.LastOrDefault());
    }
}