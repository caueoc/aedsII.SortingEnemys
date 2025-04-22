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
}
