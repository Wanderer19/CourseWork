using DataStructure.Solutions.StackTasks.StackUtils;

namespace DataStructure.Solutions.StackTasks
{
    public class ExoticClone
    {
        private Stack<int> learnedLessons;
        private Stack<int> canceledLessons;
 
        public ExoticClone()
        {
            learnedLessons = new Stack<int>();
            canceledLessons = new Stack<int>();
        }

        public void LearnLesson(int lesson)
        {
            learnedLessons.Push(lesson);
            canceledLessons.Clear();
        }

        public void Rollback()
        {
            if (!learnedLessons.IsEmpty())
                canceledLessons.Push(learnedLessons.Pop());
        }

        public void Relearn()
        {
            if (!canceledLessons.IsEmpty())
                learnedLessons.Push(canceledLessons.Pop());
        }

        public int GetLastLearnedLesson()
        {
            return learnedLessons.IsEmpty() ? 0 : learnedLessons.Peek();
        }

        public object Clone()
        {
            var exoticClone = new ExoticClone
            {
                learnedLessons = learnedLessons.Clone(),
                canceledLessons = canceledLessons.Clone()
            };
            return exoticClone;
        }
    }
}
