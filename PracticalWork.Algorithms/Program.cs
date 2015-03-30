using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PracticalWork.Algorithms.BinaryTreeUtils;

namespace PracticalWork.Algorithms
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            var n = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (var i = 0; i < n; i++)
            {
                var tmp = int.Parse(Console.ReadLine());
                list.Add(tmp);
            }

            for (var i = n - 1; i >= 0; --i)
            {
                tree.AddToTree(list[i]);
            }


            foreach (var el in tree.MyTraverse())
            {
                Console.WriteLine(el);
            }
        }
    }
}
