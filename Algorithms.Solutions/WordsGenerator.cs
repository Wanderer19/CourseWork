using System.Collections.Generic;

namespace Algorithms.Solutions
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
                //база рекурсии, если слово сформировано , добавляем его в результирующий массив слов
                words.Add(string.Join("", initial));
                return;
            }


            //перебираем все буквы алфавита и ставим в текущую позицию, и для каждого такого состояния запускаем перебор для больших позиций
            foreach (var letter in alphabet)
            {
                initial[pos] = letter;
                MakeWords(initial, pos + 1);
            }
        }
    }
}
