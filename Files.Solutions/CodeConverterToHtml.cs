using System.IO;

namespace Files.Solutions
{
    public class CodeConverterToHtml
    {
        public void ConvertToHtml(string inputFilename, string outputFilename)
        {
            var codeText = File.ReadAllLines(inputFilename);
            using (var writer = new StreamWriter(new FileStream(outputFilename, FileMode.OpenOrCreate)))
            {
                writer.WriteLine("<body>");
                writer.WriteLine("<ol>");

                foreach (var codeLine in codeText)
                {
                    writer.Write("<li>");
                    var newLine = codeLine.Replace(" ", "&nbsp;");
                    newLine = newLine.Replace(@"\t", "&nbsp;&nbsp;&npsp;&nbsp;");
                    writer.Write(newLine);
                    writer.WriteLine("</li>");
                }

                writer.WriteLine("</ol>");
                writer.WriteLine("</body>");
            }
        }
    }
}
