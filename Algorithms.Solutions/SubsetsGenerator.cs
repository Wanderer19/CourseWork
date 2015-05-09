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
                //linq выражение, которое можно заменить на цикл, в котором проверяется значение элемента в маске, и если оно true , то вернуть элемент с таким индексом
                yield return originalSet.Where((i, j) => mask[j]).ToArray();
                yield break;
            }

            mask[position] = true;
            var subsets1 = MakeSubsets(mask, originalSet, position + 1);

            // так как возвращаемое значение IEnumerable, то можно не собирать коллекцию вручную, а делать ленивый return
            // сработает при первом использовании
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
