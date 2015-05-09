using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataStructure.Solutions.DictionaryTasks.InvertedIndexUtils
{
    public static class InvertedIndexBuilder
    {
        public static Dictionary<string, List<int>> BuildInvertedIndex(Document[] documents)
        {
            var result = new Dictionary<string, List<int>>();


            //в данном цикле мы заполняем наш словарь, ключем являемя слово, а значением список id тех документов, в которых оно втсречается
            foreach (var document in documents.OrderBy(i => i.Id))
            {
                var documentTextWords = Regex.Split(document.Text.ToLower(), @"\W+")
                                                .Where(word => word != "")
                                                .Distinct();
                // при помощи регулярного выржения разбиваем текст на слова; в данном случае разделить - любой символ, не являющийся буквой. 
                //Далее идет фильтрация, остаются только не пустые слова.
                //Потом мы оставляем только не дублирубщиеся словаю

                foreach (var word in documentTextWords)
                {
                    //идем по всем словам из списка, если слова нет в словаре, то добавляем его и начальный пустой список в качестве значения
                    if (!result.ContainsKey(word))
                        result[word] = new List<int>();

                    result[word].Add(document.Id);
                }
            }

            return result;
        }

        public static Dictionary<string, List<int>> BuildInvertedIndexSecondVersion(Document[] documents)
        {
            //linq выражение (см книгу по Linq)
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
