using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Files.Solutions;
using NUnit.Framework;

namespace Files.Tests
{
    [TestFixture]
    public class ProblemDirectorySolverTests
    {
        [Test]
        public void Test()
        {
            var solver = new ProblemDirectorySolver();

            solver.Solve("DirectoryTests\\input", "DirectoryTests\\output");

            var info = new DirectoryInfo("DirectoryTests\\input");
            foreach (var file in info.EnumerateFiles())
            {
                var actual = File.ReadAllText("DirectoryTests\\output\\" + file.Name).Trim();
                var expected = File.ReadAllText("DirectoryTests\\results\\" + file.Name).Trim();

                Assert.That(actual, Is.EqualTo(expected));
            }

        }
    }
}
