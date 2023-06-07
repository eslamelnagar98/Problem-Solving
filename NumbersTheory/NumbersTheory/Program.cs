using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheetWeekOne
{
    internal class Program
    {
        private static HashSet<ulong> _tPrimeNumbers = new();
        private static Dictionary<int, int> _primeNumbersDictionary = new();
        static void Main(string[] args)
        {
            //AlmostPrimeVJudge();
            //TPrimesVJudge();
            //TenThousandFirstprime();
            //IntegerFactorization();
            //NoldbachproblemVJudge();
            //LargestPrimefactorVJudge();
            //SummationOfPrimesVJudge();
            NumberIntoSequenceVJudge();
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
}