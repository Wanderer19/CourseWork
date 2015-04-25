using System;
using NUnit.Framework;
using OOP.Solutions.LibraryUtils;

namespace OOP.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void SetUp()
        {
            library = new Library();
        }

        [Test]
        public void TestEmptyLibrary()
        {
            Assert.That(library.GetMagazinesWithName("VOGUE"), Is.Empty);
            Assert.That(library.GetMagazinesWithYear(2015), Is.Empty);
            Assert.That(library.GetMagazine(2015, 1, "VOGUE"), Is.Null);
        }


        [Test]
        public void TestFullLibrary()
        {
            var magazine1 = new Magazine("VOGUE", new DateTime(2015, 1, 1));
            magazine1.AddArticle(new Article("title1", "text1", "a1"));
            magazine1.AddArticle(new Article("title2", "text2", "a2"));
            magazine1.AddArticle(new Article("title3", "text3", "a1"));
            magazine1.AddArticle(new Article("title4", "text4", "a2"));


            var magazine2 = new Magazine("VOGUE", new DateTime(2015, 2, 1));
            magazine2.AddArticle(new Article("title1", "text1", "a1"));


            var magazine3 = new Magazine("Nylon", new DateTime(2014, 2, 1));
            magazine3.AddArticle(new Article("title1", "text1", "a1"));


            library.AddMagazine(magazine1);
            library.AddMagazine(magazine2);
            library.AddMagazine(magazine3);

            //TODO дописать тест
        }
    }
}
