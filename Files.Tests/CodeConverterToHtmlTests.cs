using System.IO;
using Files.Solutions;
using NUnit.Framework;

namespace Files.Tests
{
    [TestFixture]
    public class CodeConverterToHtmlTests
    {
        [Test]
        public void Test()
        {
            var converter = new CodeConverterToHtml();
            var dir = new DirectoryInfo("Tests");
            foreach (var file in dir.EnumerateFiles())
            {
               converter.ConvertToHtml(file.FullName, file.DirectoryName + "\\TestResults\\" +file.Name + ".result.html");
               var actualResult = File.ReadAllText(file.DirectoryName + "\\TestResults\\" + file.Name + ".result.html").Trim();
                var expectedResult = File.ReadAllText("Results\\" + file.Name + ".html").Trim();
                Assert.That(actualResult, Is.EqualTo(expectedResult));
            }
        }
    }
}
