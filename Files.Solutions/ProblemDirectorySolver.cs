using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Files.Solutions
{
    public class ProblemDirectorySolver
    {
        public void Solve(string inputDirectoryName, string outputDirectoryName)
        {
            var info = new DirectoryInfo(inputDirectoryName);
            
            Directory.CreateDirectory(outputDirectoryName);
            foreach (var file in info.EnumerateFiles())
            {
                var output = outputDirectoryName + "\\" + file.Name;
                var numbers = GetNumbersFromFile(file).Where(number => number >= 0).ToList();
                using (var writer = new StreamWriter(new FileStream(output, FileMode.OpenOrCreate)))
                {
                    foreach (var number in numbers)
                    {
                        writer.WriteLine(Math.Sqrt(number));
                    }
                }
            }
        }

        private IEnumerable<int> GetNumbersFromFile(FileInfo file)
        {
            var fileFullName = file.DirectoryName + "\\" + file.Name;
            var text = File.ReadAllText(fileFullName);

            return Regex.Replace(text, @"\s+", " ")
                        .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse);
        } 
    }
}
