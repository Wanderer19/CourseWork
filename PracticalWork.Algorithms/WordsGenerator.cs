using System.Collections.Generic;

namespace PracticalWork.Algorithms
{
    public class WordsGenerator
    {
        private readonly char[] alphabet;
        private List<string> words;
        public WordsGenerator(char[] alphabet)
        {
            this.alphabet = alphabet;
        }

        public List<string> GetWords(int maxLength)
        {
            words = new List<string>();
            MakeWords(new char[maxLength], 0);

            return words;
        }

        private void MakeWords(char[] initial, int pos)
        {
            if (pos == initial.Length)
            {
                words.Add(string.Join("", initial));
                return;
            }

            foreach (var letter in alphabet)
            {
                initial[pos] = letter;
                MakeWords(initial, pos + 1);
            }
        }
    }
}
