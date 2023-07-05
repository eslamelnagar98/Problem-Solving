using System.Collections.Generic;
using System.Linq;
namespace SortingAlgorithms;
public static class MergeSortAlgorithm
{
    internal static List<int> MergeSort(List<int> unsortedList)
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
}
