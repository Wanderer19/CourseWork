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
            for (var i = 1; i <= Content.Length; ++i)
                yield return Content.Substring(0, i);
        }

        public IEnumerable<string> GetSuffixes()
        {
            for (var i = 1; i <= Content.Length; ++i)
                yield return Content.Substring(Content.Length - i, i);
        }
    }
}
