using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Solutions
{
    public static class SubsetsGenerator
    {
        public static IEnumerable<T[]> GenerateSubstes<T>(T[] set)
        {
            return MakeSubsets(new bool[set.Length], set, 0);
        }

        private static IEnumerable<T[]> MakeSubsets<T>(bool[] mask, T[] originalSet, int position)
        {
            if (position == originalSet.Length)
            {
                yield return originalSet.Where((i, j) => mask[j]).ToArray();
                yield break;
            }

            mask[position] = true;
            var subsets1 = MakeSubsets(mask, originalSet, position + 1);
            foreach (var subset in subsets1)
            {
                yield return subset;
            }
            mask[position] = false;

            var subsets2 = MakeSubsets(mask, originalSet, position + 1);
            foreach (var subset in subsets2)
            {
                yield return subset;
            }
        }
    }
}
