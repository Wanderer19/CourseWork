using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Solutions.DictionaryTasks.PrefixSuffixUtils
{
    public static class Solver
    {
        public static Tuple<string, string, string> Solve(Word[] words)
        {
            var prefixes = new Dictionary<string, List<string>>();
            var suffixes = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                foreach (var prefix in word.GetPrefixes())
                {
                    if (!prefixes.ContainsKey(prefix))
                        prefixes[prefix] = new List<string>();

                    prefixes[prefix].Add(word.Content);
                }

                foreach (var suffix in word.GetSuffixes())
                {
                    if (!suffixes.ContainsKey(suffix))
                        suffixes[suffix] = new List<string>();

                    suffixes[suffix].Add(word.Content);
                }
            }

            foreach (var prefix in prefixes.Keys.OrderByDescending(p => p.Length))
            {
                if (suffixes.ContainsKey(prefix))
                {
                    foreach (var word in prefixes[prefix])
                    {
                        if (!suffixes[prefix].Contains(word) || suffixes[prefix].Count(w => w != word) > 0)
                        {
                            return Tuple.Create(word, suffixes[prefix].First(w => w != word), prefix);
                        }
                    }

                }
            }
            return null;
        }

        public static Tuple<string, string, string> SolveSecond(Word[] words)
        {
            var prefixes =
                words.SelectMany(word => word.GetPrefixes().Select(p => Tuple.Create(word.Content, p)))
                    .ToLookup(t => t.Item2, t => t.Item1);

            var suffixes = words.SelectMany(word => word.GetSuffixes().Select(p => Tuple.Create(word.Content, p)))
                                .ToLookup(t => t.Item2, t => t.Item1);

            return
                prefixes.OrderByDescending(k => k.Key.Length)
                        .Where(pr => suffixes.Contains(pr.Key))
                        .Select(
                                prefix =>
                                         prefixes[prefix.Key].Where(word => !suffixes[prefix.Key].Contains(word) || suffixes[prefix.Key].Count(w => w != word) > 0)
                                                            .Select(word => Tuple.Create(word, suffixes[prefix.Key].First(w => w != word), prefix.Key))
                                                            .FirstOrDefault())
                        .FirstOrDefault(i => i != null);
        }
    }
}
