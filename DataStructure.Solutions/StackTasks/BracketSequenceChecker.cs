using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Solutions.StackTasks
{
    public static class BracketSequenceChecker
    {
        private static readonly Dictionary<char, char> Brackets = new Dictionary<char, char>()
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
            {'<', '>'}
        }; 

        public static bool Check(string bracketSequence)
        {
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
