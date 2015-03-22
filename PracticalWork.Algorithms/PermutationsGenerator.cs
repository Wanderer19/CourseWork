using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalWork.Algorithms
{
    public class PermutationsGenerator<T>
    {
        private readonly List<T> elements;
        public PermutationsGenerator(List<T> elements)
        {
            this.elements = elements;
        }

        public IEnumerable<IEnumerable<T>> GetPermutations()
        {
            var permutations = MakePermutations(new int[elements.Count()], 0);
            return permutations.Select(permutation => permutation.Select(i => elements[i]));
        }

        static IEnumerable<IEnumerable<int>> MakePermutations(int[] permutation, int position)
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
