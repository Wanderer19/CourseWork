using System.Collections.Generic;

namespace DataStructure.Solutions.DictionaryTasks.PrefixSuffixUtils
{
    public class Word
    {
        public string Content { get; private set; }
        public Word(string content)
        {
            Content = content;

        }

        public IEnumerable<string> GetPrefixes()
        {
            //Префикс слова - любая подстрока, начинающаяся в начале слова. В том числе само слово является свои префиксом
            for (var i = 1; i <= Content.Length; ++i)
                yield return Content.Substring(0, i);
        }

        public IEnumerable<string> GetSuffixes()
        {
           //Суффикс - любая подстрока, конец которой - конец нашего слова. В том числе само слово является свои суффиксом
            for (var i = 1; i <= Content.Length; ++i)
                yield return Content.Substring(Content.Length - i, i);
        }
    }
}
