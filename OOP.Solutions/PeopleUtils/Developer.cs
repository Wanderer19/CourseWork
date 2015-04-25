using System;

namespace OOP.Solutions.PeopleUtils
{
    public class Developer :Employee
    {
        public string ProgrammingLanguage { get; set; }
        public Developer(string firstName, string lastName, int age, string programmingLanguage, double salary) : base(firstName, lastName, age, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public double GetPrize()
        {
            return base.GetSalary()/2 + 1;
        }

        public void WriteCode()
        {
            Console.WriteLine("Я пишу код на {0}", ProgrammingLanguage);
        }
    }
}
