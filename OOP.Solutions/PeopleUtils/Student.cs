using System;

namespace OOP.Solutions.PeopleUtils
{
    public class Student : Man
    {
        public string UniversityName { get; set; }
        public Student(string firstName, string lastName, int age, string universityName)
            :base(firstName, lastName, age)
        {
            UniversityName = universityName;
        }

        public void DoCoursework(string theme)
        {
            Console.WriteLine("Скоро начну....");
        }
    }
}
