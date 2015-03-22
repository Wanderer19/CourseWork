using System;

namespace PracticalWork.Algorithms.SearcherUtils
{
    public class Searcher<T> where T : IComparable
    {
        public int LinearSearch(T[] source, T element)
        {
            for (var i = 0; i < source.Length; ++i)
            {
                if (source[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public int BinarySearch(T[] source, T element)
        {
            //Работает, если source отсортирован в нужном порядке
            var left = 0;
            var right = source.Length - 1;

            while (left < right)
            {
                var middle = (left + right) / 2;
                if (source[middle].CompareTo(element) > -1) // element <= source[middle]
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }

            if (left < source.Length && source[left].Equals(element))
                return left;
            return -1;
        }
    }
}
