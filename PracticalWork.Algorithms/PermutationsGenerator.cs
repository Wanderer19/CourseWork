using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalWork.Algorithms
{
    public static class PermutationsGenerator
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(List<T> elements)
        {
            var permutations = MakePermutations(new int[elements.Count()], 0);
            return permutations.Where(permutation => permutation.Count() != 0).Select(permutation => permutation.Select(i => elements[i]));
        }

        private static IEnumerable<IEnumerable<int>> MakePermutations(int[] permutation, int position)
        {
            if (position == permutation.Length)
            {
                yield return new List<int>(permutation);
            }

            for (var i = 0; i < permutation.Length; i++)
            {
                var index = Array.IndexOf(permutation, i, 0, position);
                if (index != -1)
                    continue;
                permutation[position] = i;
                foreach (var makePermutation in MakePermutations(permutation, position + 1))
                {
                    yield return makePermutation;
                }
            }
        }
    }
}
