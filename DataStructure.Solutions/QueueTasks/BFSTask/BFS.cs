using System;
using System.Collections.Generic;

namespace DataStructure.Solutions.QueueTasks.BFSTask
{
    public static class Bfs
    {
        public static IEnumerable<Tuple<int, int>> SearchPath(int[,] graph, int start, int finish, int n)
        {
            // нам нужны 2 массива
            /* used[i] -означает, просмотрели мы данный элемень в нашем поиске или еще нет
             * 
             * parent[i] - содержит родителя, то есть номер вершины, из которой мы можем прийти в данную кратчайшим путем
             * */
            var used = new bool[n];
            var parent = new int[n];


            //лучше начинать с конечной вершины, чтобы при формировании пути не приходилось его разворачивать
            used[finish] = true;
            parent[finish] = start;

            var queue = new QueueUtils.Queue<int>();
            queue.Enqueue(finish);

            /*Пока в очереди есть элементы , берем элемент из начала очереди
             * Пробегаемся по всем его непросмотренным детям
             * Помечаем их как просмотренные и кидаем в очередь
             * И помечаем их родителя 
             */
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

            // если наша стартовая вершина не просмотрена, то значит пути до нее не существует
            if (!used[start])
                yield break;

            var tmp = start;
            //идем по массиву родителей в обратном порядке
            // Но так как мы искали путь от конченой до старотовой, то получается как раз нужный нам порядок ребер в пути
            while (tmp != finish)
            {
                yield return Tuple.Create(tmp, parent[tmp]);
                tmp = parent[tmp];
            }
        }
    }
}
