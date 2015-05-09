using DataStructure.Solutions.StackTasks;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    public class ExoticCloneTests
    {
        [Test]
        public void Test()
        {
            var clone = new ExoticClone();
            clone.LearnLesson(5);
            clone.LearnLesson(1);
            clone.Rollback();

            Assert.That(clone.GetLastLearnedLesson(), Is.EqualTo(5));

            var newClone = (ExoticClone)clone.Clone();
            Assert.That(newClone.GetLastLearnedLesson(), Is.EqualTo(5));

            clone.Relearn();
            Assert.That(clone.GetLastLearnedLesson(), Is.EqualTo(1));
            Assert.That(newClone.GetLastLearnedLesson(), Is.EqualTo(5));

            newClone.LearnLesson(6);
            Assert.That(clone.GetLastLearnedLesson(), Is.EqualTo(1));
            Assert.That(newClone.GetLastLearnedLesson(), Is.EqualTo(6));
        }

    }
}
