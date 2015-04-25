using System;

namespace OOP.Solutions.PeopleUtils
{
    public class Employee:Man
    {
        private readonly double salary;
        public Employee(string firstName, string lastName, int age, double salary) : base(firstName, lastName, age)
        {
            this.salary = salary;
        }

        public double GetSalary()
        {
            return salary - salary/10;
        }

        public void GoToWork()
        {
            Console.WriteLine("Я пошел работать!");
        }
    }
}
