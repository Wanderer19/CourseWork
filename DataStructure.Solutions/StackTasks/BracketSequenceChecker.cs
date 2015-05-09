using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Solutions.StackTasks
{
    public static class BracketSequenceChecker
    {
        // словарь, в котором ключ - открывающая скобка, а значение - соответсвующая ей закрывающая скобка
        private static readonly Dictionary<char, char> Brackets = new Dictionary<char, char>()
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
            {'<', '>'}
        }; 

        public static bool Check(string bracketSequence)
        {
            /*идем по строке, если втсретили открывающую скобку, то вталкиваем ее в стек
             * если закрывающую, то в том случае, если последовательность правильная, соответсвующая ей открывающая уже должна быть в стеке
             * если стек пуст, то значит последовательность неправиьная, то есть произошел случай вроде такого (()))
             * так же надо проверить, соответсвует ли открывающая скобка текущей закрывающей. Для этого нам и нужен словарь.
             *в конце, если стек не пуст, значит произошел случай вроде такого (()
             *значит последовательность неправильная
             */
            var stack = new StackUtils.Stack<char>();
            foreach (var ch in bracketSequence)
            {
                if (Brackets.Keys.Contains(ch))
                {
                    stack.Push(ch);
                }
                else if (Brackets.Values.Contains(ch))
                {
                    var peek = stack.Pop();
                    if (Brackets[peek] != ch)
                    {
                        return false;
                    }
                }
            }
            return stack.IsEmpty();
        }
    }
}
