using SortingEnemys.enemys;
using System;

public class Sorters
{
    public static void BubbleSort(Enemy[] array, Func<Enemy, int> keySelector)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] == null || array[j + 1] == null) continue;
                if (keySelector(array[j]) > keySelector(array[j + 1]))
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
    public static void SelectionSort(Enemy[] array, Func<Enemy, int> keySelector)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] == null) continue;
                if (array[minIdx] == null || keySelector(array[j]) < keySelector(array[minIdx]))
                {
                    minIdx = j;
                }
            }
            if (minIdx != i)
            {
                (array[i], array[minIdx]) = (array[minIdx], array[i]);
            }
        }
    }
    public static void InsertionSort(Enemy[] array, Func<Enemy, int> keySelector)
    {
        for (int i = 1; i < array.Length; i++)
        {
            var key = array[i];
            if (key == null) continue;

            int j = i - 1;
            while (j >= 0 && array[j] != null && keySelector(array[j]) > keySelector(key))
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
    public static void ShellSort(Enemy[] array, Func<Enemy, int> keySelector)
    {
        for (int i = array.Length / 2; i > 0; i /= 2)
        {
            for (int j = i; i < array.Length; j++)
            {
                var currentKey = array[j];
                var k = j;
                while (k >= i && keySelector(array[k - i]) > keySelector(currentKey))
                {
                    array[k] = array[k - i];
                }
                array[k] = currentKey;
            }
        }
    }
    public static void QuickSort(Enemy[] array, Func<Enemy, int> keySelector)
    {
        QuickSortRecursive(array, 0, array.Length - 1, keySelector);
    }

    private static void QuickSortRecursive(Enemy[] array, int low, int high, Func<Enemy, int> keySelector)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high, keySelector);
            QuickSortRecursive(array, low, pi - 1, keySelector);
            QuickSortRecursive(array, pi + 1, high, keySelector);
        }
    }

    private static int Partition(Enemy[] array, int low, int high, Func<Enemy, int> keySelector)
    {
        var pivot = array[high];
        if (pivot == null) return high;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] != null && keySelector(array[j]) < keySelector(pivot))
            {
                i++;
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        (array[i + 1], array[high]) = (array[high], array[i + 1]);
        return i + 1;
    }
    public static void MergeSort(Enemy[] array, Func<Enemy, int> keySelector)
    {
        MergeSortRecursive(array, 0, array.Length - 1, keySelector);
    }

    private static void MergeSortRecursive(Enemy[] array, int left, int right, Func<Enemy, int> keySelector)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSortRecursive(array, left, mid, keySelector);
            MergeSortRecursive(array, mid + 1, right, keySelector);
            Merge(array, left, mid, right, keySelector);
        }
    }

    private static void Merge(Enemy[] array, int left, int mid, int right, Func<Enemy, int> keySelector)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        Enemy[] L = new Enemy[n1];
        Enemy[] R = new Enemy[n2];

        Array.Copy(array, left, L, 0, n1);
        Array.Copy(array, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
        {
            if (L[i] == null) { i++; continue; }
            if (R[j] == null) { j++; continue; }

            if (keySelector(L[i]) <= keySelector(R[j]))
                array[k++] = L[i++];
            else
                array[k++] = R[j++];
        }

        while (i < n1)
            array[k++] = L[i++];
        while (j < n2)
            array[k++] = R[j++];
    }
    public static void HeapSort(Enemy[] array, Func<Enemy, int> keySelector)
    {
        int n = array.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i, keySelector);

        for (int i = n - 1; i >= 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            Heapify(array, i, 0, keySelector);
        }
    }

    private static void Heapify(Enemy[] array, int n, int i, Func<Enemy, int> keySelector)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if (l < n && array[l] != null && array[largest] != null &&
            keySelector(array[l]) > keySelector(array[largest]))
            largest = l;

        if (r < n && array[r] != null && array[largest] != null &&
            keySelector(array[r]) > keySelector(array[largest]))
            largest = r;

        if (largest != i)
        {
            (array[i], array[largest]) = (array[largest], array[i]);
            Heapify(array, n, largest, keySelector);
        }
    }


}
