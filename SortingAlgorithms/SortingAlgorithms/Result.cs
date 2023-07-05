using System;
using System.Collections.Generic;

namespace SortingAlgorithms;
public class Result
{
    public static List<int> quickSort(List<int> arr)
    {
        QuickSort(arr, 0, arr.Count - 1);
        return arr;
    }
    private static void QuickSort(List<int> unSortedList, int left, int right)
    {
        if (left < right)
        {
            (var pivotFirstAccurnce, var pivotLastAccurnce) = Partition(unSortedList, left, right);
            QuickSort(unSortedList, left, pivotFirstAccurnce - 1);
            QuickSort(unSortedList, pivotLastAccurnce + 1, right);
        }
    }

    private static Tuple<int, int> Partition(List<int> unSortedList, int leftIndex, int rightIndex)
    {
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

}

