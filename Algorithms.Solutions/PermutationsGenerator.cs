using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Solutions
{
    public static class PermutationsGenerator<T>
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations(List<T> elements)
        {
            var permutations = MakePermutations(new int[elements.Count()], 0);

            //linq выражение, которое можно заменить на обычый цикл. Прбегаемся по всем перестановкам, заменяем индекс на соответсвующий ей элемент в исходном списке.
            return permutations.Select(permutation => permutation.Select(i => elements[i]));
        }

        private static IEnumerable<IEnumerable<int>> MakePermutations(int[] permutation, int position)
        {
            if (position == permutation.Length)
            {
                //база рекурсии
                yield return new List<int>(permutation);
                yield break;
            }

            for (var i = 0; i < permutation.Length; i++)
            {
                //ищем индексы, которые еще не присутствуют в перестановке
                //можно такую проверку сделать циклом, но так более лаконично
                var index = Array.IndexOf(permutation, i, 0, position);
                if (index != -1)
                    continue;
                permutation[position] = i;
                //так как рекурсия, то нам необходимо вовзратить все значения, которые вернут последующий вызов
                foreach (var makePermutation in MakePermutations(permutation, position + 1))
                {
                    yield return makePermutation;
                }
            }
        }
    }
}
