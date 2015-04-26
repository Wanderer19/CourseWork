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
            var decoder = new  CodeConverterToHtml();
            decoder.ConvertToHtml("AccountController.cs", "AccountController.cs.html");
        }
    }
}
