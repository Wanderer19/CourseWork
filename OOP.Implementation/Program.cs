using System;
using OOP.Implementation.CompositeUtils;

namespace OOP.Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var cabinet = new Cabinet("PC Cabinet", 100, 100);
            var chassis = new Chassis("PC Chassis", 55, 45);

            cabinet.Add(chassis);


            var bus = new Bus("MCA Bus", 190, 189.99m);
            bus.Add(new Card("16Mbs Token Ring", 33, 30));

            chassis.Add(bus);
            chassis.Add(new FloppyDisk("3.5in Floppy", 12, 12));

            var price = cabinet.NetPrice;
            Console.WriteLine(price);
        }
    }
}
