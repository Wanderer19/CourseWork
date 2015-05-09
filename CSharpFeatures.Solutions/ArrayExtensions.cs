using System;
using System.Collections.Generic;

namespace CSharpFeatures.Solutions
{
    public static class ArrayExtensions
    {
        //ключевое слово this делает обычный статический метод "как бы" динамическим методом того класса, который указан после этого слова в первом аргументе.
        public static void Swap<T>(this T[] array, int i, int j)
        {
            if (i < 0 || i >= array.Length || j < 0 || j >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        public static void Shuffle<T>(this T[] array)
        {
            var random = new Random();
            for (var i = 0; i < array.Length; ++i)
            {
                var index = random.Next(i, array.Length - 1);
                array.Swap(i, index);
            }
        }

        public static T[] Slice<T>(this T[] array, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (count < 0)
            {
                throw new ArgumentException();
            }

            var bound = Math.Min(array.Length - startIndex, count);
            var slice = new List<T>();
            for (var i = startIndex; i < bound + startIndex; ++i)
            {
                slice.Add(array[i]);
            }

            return slice.ToArray();
        }
    }
}
