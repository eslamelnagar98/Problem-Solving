using System.Collections.Generic;
using System.Linq;
namespace SortingAlgorithms;
public class HackerRankMergeSort
{
    public static long CountInversions(List<int> arr)
    {
        return MergeSort(arr);
    }

    private static long MergeSort(List<int> unsortedList)
    {
        if (unsortedList.Count <= 1)
        {
            return 0;
        }
        var chunkSize = unsortedList.Count >> 1;
        var leftList = unsortedList.Take(chunkSize).ToList();
        var rightList = unsortedList.Skip(chunkSize).ToList();
        var inversionCount = MergeSort(leftList);
        inversionCount += MergeSort(rightList);
        inversionCount += Merge(leftList, rightList, unsortedList);
        return inversionCount;
    }

    private static long Merge(List<int> left, List<int> right, List<int> merged)
    {
        var inversionCount = 0L;
        var leftIndex = 0;
        var rightIndex = 0;
        var mergedIndex = 0;
        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            if (left[leftIndex] <= right[rightIndex])
            {
                merged[mergedIndex] = left[leftIndex];
                leftIndex++;
            }
            else
            {
                merged[mergedIndex] = right[rightIndex];
                rightIndex++;
                inversionCount += left.Count - leftIndex;
            }
            mergedIndex++;
        }
        while (leftIndex < left.Count)
        {
            merged[mergedIndex] = left[leftIndex];
            leftIndex++;
            mergedIndex++;
        }
        while (rightIndex < right.Count)
        {
            merged[mergedIndex] = right[rightIndex];
            rightIndex++;
            mergedIndex++;
        }
        return inversionCount;
    }
}
