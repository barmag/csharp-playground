//Quick Sort
using System;
class Solution
{
    static void Main(String[] args)
    {
        //Initializing array
        int[] arr = { 9, 4, 8, 3, 1, 2, 5 };
        Console.Write("Initial Array : ");
        Console.WriteLine(String.Join(" ", arr));
        quickSort(arr, 0, arr.Length - 1);
    }
    //Sorting in non decreasing order
    private static void quickSort(int[] arr, int i, int j)
    {
        if (i < j)
        {
            int pos = partition(arr, i, j);
            quickSort(arr, i, pos - 1);
            quickSort(arr, pos + 1, j);
        }
    }

    private static int partition(int[] arr, int i, int j)
    {
        int pivot = arr[j];
        int small = i - 1;

        for (int k = i; k < j; k++)
        {
            if (arr[k] <= pivot)
            {
                small++;
                swap(arr, k, small);
            }
        }

        swap(arr, j, small + 1);
        Console.WriteLine("Pivot = " + arr[small + 1]);
        Console.WriteLine(String.Join(" ", arr));
        return small + 1;
    }

    private static void swap(int[] arr, int k, int small)
    {
        int temp;
        temp = arr[k];
        arr[k] = arr[small];
        arr[small] = temp;
    }


}