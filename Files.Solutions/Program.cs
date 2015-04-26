using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Solutions
{
    class Program
    {
        static void Main(string[] args)
        {
            var decoder = new Decoder();
            var result = decoder.Decode("67.result", "Yo", "Nice");
            Console.WriteLine(result);
        }
    }
}
