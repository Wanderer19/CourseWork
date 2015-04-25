using System;
using System.Collections.Generic;

namespace DataStructure.Solutions.QueueTasks.BFSTask
{
    public static class Bfs
    {
        public static IEnumerable<Tuple<int, int>> SearchPath(int[,] graph, int start, int finish, int n)
        {
            var used = new bool[n];
            var parent = new int[n];

            used[finish] = true;
            parent[finish] = start;

            var queue = new QueueUtils.Queue<int>();
            queue.Enqueue(finish);
            while (!queue.IsEmpty())
            {
                var top = queue.Dequeue();

                for (var i =0; i < n; ++i)
                {
                    if (graph[top, i] == 1 && !used[i])
                    {
                        used[i] = true;
                        parent[i] = top;
                        queue.Enqueue(i);
                    }
                }
            }

            if (!used[start])
                yield break;

            var tmp = start;
            while (tmp != finish)
            {
                yield return Tuple.Create(tmp, parent[tmp]);
                tmp = parent[tmp];
            }
        }
    }
}
