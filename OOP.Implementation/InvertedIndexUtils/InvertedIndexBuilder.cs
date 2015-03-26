using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OOP.Implementation.InvertedIndexUtils
{
    public static class InvertedIndexBuilder
    {
        public static Dictionary<string, List<int>> BuildInvertedIndex(Document[] documents)
        {
            var result = new Dictionary<string, List<int>>();

            foreach (var document in documents.OrderBy(i => i.Id))
            {
                var documentTextWords = Regex.Split(document.Text.ToLower(), @"\W+")
                                                .Where(word => word != "")
                                                .Distinct();

                foreach (var word in documentTextWords)
                {
                    if (!result.ContainsKey(word))
                        result[word] = new List<int>();

                    result[word].Add(document.Id);
                }
            }

            return result;
        }

        public static Dictionary<string, List<int>> BuildInvertedIndexSecondVersion(Document[] documents)
        {
            return documents.SelectMany(document => Regex.Split(document.Text.ToLower(), @"\W+")
                                                            .Where(word => word != "")
                                                            .Distinct()
                                                            .Select(ii => Tuple.Create(ii, document.Id))
                                       )
                                .GroupBy(i => i.Item1)
                                .ToDictionary(i => i.Key, i => i.Select(g => g.Item2).OrderBy(j => j).ToList());
        } 
    }
}
