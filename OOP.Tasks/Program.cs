using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Implementation.PrefixSuffixUtils;

namespace OOP.Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("ruwords.txt").Select(word => new Word(word)).ToArray();
            var result = Task1.Solve(words);
            File.WriteAllText("res.txt", string.Format("{0} - {1}", result.Item1, result.Item2));
            Console.WriteLine("{0} - {1}", result.Item1, result.Item2);
        }
    }
}
