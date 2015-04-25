using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP.Solutions.LibraryUtils
{
    public class Library
    {
        private readonly List<Magazine> magazines;

        public Library()
        {
            magazines = new List<Magazine>();
        }

        public IEnumerable<Magazine> GetMagazinesWithName(string name)
        {
            return magazines.Where(magazine => magazine.Name == name);
        }

        public IEnumerable<Magazine> GetMagazinesWithYear(int year)
        {
            return magazines.Where(magazine => magazine.Release.Year == year);
        }

        public Magazine GetMagazine(int year, int month, string name)
        {
            return magazines.FirstOrDefault(magazine => magazine.Release.Year == year && magazine.Release.Month == month && magazine.Name == name);
        }

        public void AddMagazine(Magazine magazine)
        {
            if (magazines.Any(m => m.Name == magazine.Name && m.Release.Year == magazine.Release.Year && m.Release.Month == magazine.Release.Month))
            {
                throw new InvalidOperationException("Такой журнал уже есть в библиотеке");
            }

            magazines.Add(magazine);
        }
    }
}
