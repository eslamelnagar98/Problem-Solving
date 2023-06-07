using System;
using System.Collections.Generic;
using System.Linq;

namespace SheetWeekOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RotateLeftVJudge();
            //GreedyFloristVJudge();
            //PermutationVJudge();
            //TaxiVJudge();
            //HelloRecursionVJudge();
            //Game32VJudge();
            //int l = 2, r = 7;
            //rec(0, l, r);
            //int ans = 0;
            //while (l <= r)
            //{

            //    var it = s.lower_bound(l);
            //    ans = ans + (*it) * (min(r, *it) - l + 1);
            //    l = *it + 1;
            //}
            //cout << ans << endl;
            //UnluckyTicketVJudge();
            CDVJudge();

        }

        private static void CDVJudge()
        {
            var line = string.Empty;
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var lineList = line.Split(' ').Select(int.Parse).ToList();
                var cdSize = lineList.First();
                var durationDictionary = lineList
                    .Skip(2)
                    .ToDictionary(key => key, key => false)
                    ;
                var taken = new List<int>();
                var max = default(int);
                Solve(durationDictionary, cdSize, ref taken, ref max);
                foreach (var item in taken)
                {
                    Console.WriteLine(item);

                }
            }
        }

        private static void Solve(Dictionary<int, bool> vistiedTracks, int cdSize, ref List<int> taken, ref int max, int sum = 0)
        {
            if (cdSize < sum)
            {
                return;
            }
            if (sum > max)
            {
                max = sum;
                taken = vistiedTracks.Where(track => track.Value)
                    .Select(track => track.Key)
                    .ToList();
            }
            foreach (var vistiedTrack in vistiedTracks)
            {
                if (vistiedTrack.Value)
                {
                    continue;
                }
                vistiedTracks[vistiedTrack.Key] = true;
                Solve(vistiedTracks, cdSize, ref taken, ref max, sum + vistiedTrack.Key);
                vistiedTracks[vistiedTrack.Key] = false;
            }
        }

        private static void UnluckyTicketVJudge()
        {
            var number = int.Parse(Console.ReadLine());
            var numbersChunk = Console.ReadLine()
                .Chunk(number);
            var leftList = numbersChunk.FirstOrDefault()
                .OrderBy(number => number)
                .Select(charcter => int.Parse(charcter.ToString()))
                .ToList();
            var rightList = numbersChunk.LastOrDefault()
                .OrderBy(number => number)
                .Select(charcter => int.Parse(charcter.ToString()))
                .ToList();
            Console.WriteLine(Solve(number, leftList, rightList) ? "YES" : "NO");
        }

        private static bool Solve(int length, List<int> leftList, List<int> rightList, int leftCount = 0, int rightCount = 0, int position = 0)
        {
            if (position == length)
            {
                return leftCount == length || rightCount == length;
            }
            if (leftList[position] > rightList[position])
            {
                return Solve(length, leftList, rightList, leftCount + 1, position: position + 1);
            }
            else if (leftList[position] < rightList[position])
            {
                return Solve(length, leftList, rightList, rightCount: rightCount + 1, position: position + 1);
            }
            return false;
        }

        private static void HelloRecursionVJudge()
        {
            var testCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                var numbers = Console.ReadLine().Split(' ').Select(int.Parse);
                var length = numbers.FirstOrDefault();
                var list = numbers.Skip(1).Take(numbers.Count() - 1).ToList();
                Console.WriteLine($"Case {i + 1}: {Solve(list, 0)}");
            }
        }

        private static int Solve(List<int> numbers, int count)
        {
            if (count == numbers.Count)
            {
                return default;
            }
            return numbers[count] + Solve(numbers, count + 1);
        }

        private static void PermutationVJudge()
        {
            //6 6 6 6 6
            //6
            var listCount = Convert.ToInt32(Console.ReadLine());
            var intList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            var numberSet = new HashSet<int>(intList);
            var count = default(int);
            for (int i = 1; i <= listCount; i++)
            {
                if (!numberSet.Contains(i))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static void TaxiVJudge()
        {
            _ = Console.ReadLine();
            var groupsCount = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Array.Sort(groupsCount);
            var tail = groupsCount.Length - 1;
            var head = 0;
            var capacity = default(int);
            var count = default(int);
            // 1 1 1 1 2 2 2 3 3 3 4 4 4 4
            while (tail >= head)
            {
                capacity = groupsCount[tail]; //4

                while (head < groupsCount.Length && groupsCount[head] + capacity <= 4)
                {
                    capacity += groupsCount[head++];
                }
                tail--;
                count++;
            }
            Console.WriteLine(count);
        }

        private static void Game32VJudge()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse);
            var smallNumber = line.First();
            var bigNumber = line.Last();
            var result = SolveGame32(smallNumber, bigNumber);
            Console.WriteLine(result);
        }

        private static int SolveGame32(int smallNumber, int bigNumber)
        {
            var numberOfMoves = default(int);
            var number = bigNumber / smallNumber;
            if (bigNumber % smallNumber != 0)
            {
                return -1;
            }

            while (number % 2 == 0)
            {
                numberOfMoves++;
                number >>= 1;
            }
            while (number % 3 == 0)
            {
                numberOfMoves++;
                number /= 3;
            }

            if (number is not 1)
            {
                return -1;
            }
            return numberOfMoves;
        }


    }
}
