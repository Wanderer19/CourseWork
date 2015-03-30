using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork.Algorithms
{
    public class Graph
    {
        private readonly List<List<int>> matrix;

        public Graph(int vertexCount)
        {
            matrix = new List<List<int>>();
            for (var i = 0; i < vertexCount; ++i)
            {
                matrix.Add(new List<int>());
            }
        }

        public void AddEdge(int x, int y)
        {
            matrix[x].Add(y);
        }

        public List<int> GetEdges(int x)
        {
            return matrix[x];
        } 

    }
    public class BFS
    {
        
    }
}
