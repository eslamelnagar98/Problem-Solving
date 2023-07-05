using System;
using System.Collections.Generic;
using System.Linq;
namespace SortingAlgorithms;
internal class Program
{
    private static void Main(string[] args)
    {
        //var random = new Random();
        //var randomNumbers = Enumerable.Range(0, 3)
        //    .Select(_ => random.Next(1, 9))
        //    .ToList();

        //var sortedList = HackerRankMergeSort.CountInversionsHackerRank(randomNumbers);
        //Console.WriteLine("Sorted List: " + JsonSerializer.Serialize(sortedList));
        //QuickSort(randomNumbers, 0, randomNumbers.Count - 1);
        //Console.WriteLine(JsonSerializer.Serialize(randomNumbers));

        //CountingInversionsVJudge();
        PartitionVJudge();
       
    }

    private static void PartitionVJudge()
    {
        _ = Console.ReadLine();
        var list = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        QuickSort(list, 0, list.Count - 1);
        //Console.WriteLine(string.Join(' ', list));
    }

    private static void CountingInversionsVJudge()
    {
        var testCases = short.Parse(Console.ReadLine());
        while (testCases-- is not 0)
        {
            _ = Console.ReadLine();
            var list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            Console.WriteLine(HackerRankMergeSort.CountInversions(list));
        }
    }

    private static void QuickSort(List<int> unSortedList, int left, int right)
    {
        if (left < right)
        {
            (var pivotFirstAccurnce, var pivotLastAccurnce) = Partition(unSortedList, left, right);
            QuickSort(unSortedList, left, pivotFirstAccurnce - 1);
            QuickSort(unSortedList, pivotLastAccurnce + 1, right);
            PrineSubList(unSortedList, left, right);
        }
    }

    private static void PrineSubList(List<int> unSortedList, int left, int right)
    {
        for (int i = left; i <= right; i++)
        {
            Console.Write(unSortedList[i]);
            if (i != right)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

    private static Tuple<int, int> Partition(List<int> unSortedList, int leftIndex, int rightIndex)
    {
        #region Explain Wiht Example
        ///0,1,2,3
        ///3,7,1,3
        ///firstMid=-1
        ///secondMid=0
        ///i=1,2
        ///arr[i(2)]<arr[secondMid(0)]
        ///Swap(arr[0],arr[2])=> Swap(3,1)
        ///0,1,2,3 
        ///1,7,3,3 => firstMid=0
        ///Swap(arr[1],arr[2])
        ///0,1,2,3 
        ///1,3,7,3 => secondMid=1
        ///i=3
        ///arr[1]==arr[3]
        ///Swap(arr[1],arr[3])
        ///0,1,2,3 
        ///1,3,3,7 => secondMid=2
        ///return (1,2) 
        #endregion
        var firstMid = leftIndex - 1;
        var secondMid = leftIndex;
        for (int i = leftIndex + 1; i <= rightIndex; i++)
        {
            if (unSortedList[i] < unSortedList[secondMid])
            {
                Swap(unSortedList, ++firstMid, i);
                Swap(unSortedList, ++secondMid, i);
            }
            else if (unSortedList[i] == unSortedList[secondMid])
            {
                Swap(unSortedList, ++secondMid, i);
            }
        }
        return Tuple.Create(firstMid + 1, secondMid);
    }


    private static void Swap(List<int> unSortedList, int leftIndex, int rightIndex)
    {
        var temp = unSortedList[leftIndex];
        unSortedList[leftIndex] = unSortedList[rightIndex];
        unSortedList[rightIndex] = temp;
    }

    private static List<int> MergeSort(List<int> unsortedList)
    {
        if (unsortedList.Count <= 1)
        {
            return unsortedList;
        }
        var chunkSize = unsortedList.Count >> 1;
        var leftList = unsortedList.Take(chunkSize)
            .ToList();
        var rightList = unsortedList.Skip(chunkSize)
            .ToList();
        leftList = MergeSort(leftList);
        rightList = MergeSort(rightList);
        return Merge(leftList, rightList);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        var sortedList = new List<int>();
        var desireValue = default(int);
        while (left.Any() || right.Any())
        {
            if (left.Count > 0 && right.Count > 0)
            {
                desireValue = HandleLeftAndRightListNotEmpty(left, right);
                sortedList.Add(desireValue);
            }
            else if (left.Count > 0)
            {
                desireValue = HandleOneListIsEmpty(left);
                sortedList.Add(desireValue);
            }
            else if (right.Count > 0)
            {
                desireValue = HandleOneListIsEmpty(right);
                sortedList.Add(desireValue);
            }
        }
        return sortedList;
    }

    private static int HandleLeftAndRightListNotEmpty(List<int> left, List<int> right)
    {
        var desireValue = default(int);
        if (left.FirstOrDefault() <= right.FirstOrDefault())
        {
            desireValue = GetDesireValueAndRemoveItFromTheList(left);
        }
        else
        {
            desireValue = GetDesireValueAndRemoveItFromTheList(right);
        }
        return desireValue;
    }

    private static int HandleOneListIsEmpty(List<int> list)
    {
        var desireValue = list.FirstOrDefault();
        list.RemoveAt(0);
        return desireValue;
    }

    private static int GetDesireValueAndRemoveItFromTheList(List<int> list)
    {
        var desireValue = list.FirstOrDefault();
        list.RemoveAt(0);
        return desireValue;
    }

    private static void PrintSubArrays(List<int> list, int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }
}

