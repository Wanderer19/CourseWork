using System;

namespace OOP.Solutions.PeopleUtils
{
    public class Man
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Man(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void GoToSleep()
        {
            Console.WriteLine("Я пошел спать");
        }

        public void WakeUp()
        {
            Console.WriteLine("Я проснулся");
        }
    }
}
