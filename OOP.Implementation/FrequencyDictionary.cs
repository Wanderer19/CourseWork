using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP.Implementation
{
    public static class FrequencyDictionary
    {

        public static Dictionary<string, int> GetFrequenciesAtText(string text)
        {
            var words =
                text.Split(new char[] {' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var frequencies = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!frequencies.ContainsKey(word))
                    frequencies[word] = 0;

                frequencies[word]++;
            }

            return frequencies;
        }

        public static Dictionary<string, int> GetFrequenciesAtTextSecondVersion(string text)
        {

            return
                text.Split(new char[] {' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(word => word)
                    .ToDictionary(key => key.Key, key => key.Count());
        }
    }
}
