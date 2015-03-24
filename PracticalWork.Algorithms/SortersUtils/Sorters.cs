using System;

namespace PracticalWork.Algorithms.SortersUtils
{
    public static class Sorters
    {
        public static void BubbleSort<T>(T[] array) where T : IComparable
        {
            for (var i = 1; i < array.Length; ++i)
            {
                for (var j = 0; j < array.Length - 1; ++j)
                {
                    if (array[j].CompareTo(array[j + 1]) == 1)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }

        }

        public static void SelectSort<T>(T[] array) where T : IComparable
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[min]) == -1)
                        min = j;

                }

                var dummy = array[i];
                array[i] = array[min];
                array[min] = dummy;
            }
        }
    }
}
