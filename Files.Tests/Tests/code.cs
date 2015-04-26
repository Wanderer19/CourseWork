using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Files.Solutions
{
    public class Decoder
    {
        public string Decode(string fileName, string letterId, string wordEndId)
        {
            var cipher = File.ReadAllText(fileName);
            var cipherWords = Regex.Split(cipher, @"\W").Where(word => word == letterId || word == wordEndId).ToArray();

            var result = new StringBuilder();
            var count = 0;
            for (var i = 0; i < cipherWords.Length; ++i)
            {
                var word = cipherWords[i];
                if (word == letterId)
                {
                    count++;
                }
                else if (word == wordEndId)
                {
                    result.Append(Convert.ToChar(96 + count));
                    if (i < cipherWords.Length - 1 && cipherWords[i + 1] == wordEndId)
                    {
                        i++;
                        result.Append(" ");
                    }
                    count = 0;
                }
            }
            return result.ToString();
        }
    }
}
