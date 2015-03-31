using NUnit.Framework;
using OOP.Implementation.CompositeUtils;
using OOP.Solutions.CompositeUtils;

namespace OOP.Tests
{
    [TestFixture]
    public class CompositeTests
    {
        [Test]
        public void Test1()
        {
            var cabinet = new Cabinet("PC", 100, 99.99m);
            Assert.That(cabinet.NetPrice, Is.EqualTo(100));
            Assert.That(cabinet.DiscountPrice, Is.EqualTo(99.99m));
            Assert.That(cabinet.Name, Is.EqualTo("PC"));
        }

        [Test]
        public void Test2()
        {
            var floppyDisk = new FloppyDisk("3.15in Floppy", 55, 45);

            Assert.That(floppyDisk.Name, Is.EqualTo("3.15in Floppy"));
            Assert.That(floppyDisk.NetPrice, Is.EqualTo(55));
            Assert.That(floppyDisk.DiscountPrice, Is.EqualTo(45));
        }

        [Test]
        public void Test3()
        {
            var bus = new Bus("MCA Bus", 5, 5);
            bus.Add(new Card("Card1", 10, 5));
            bus.Add(new Card("Card2", 11, 11));

            Assert.That(bus.Name, Is.EqualTo("MCA Bus"));
            Assert.That(bus.NetPrice, Is.EqualTo(26));
            Assert.That(bus.DiscountPrice, Is.EqualTo(21));
        }

        [Test]
        public void Test4()
        {
            var cabinet = new Cabinet("PC Cabinet", 100, 100);
            var chassis = new Chassis("PC Chassis", 55, 45);

            cabinet.Add(chassis);


            var bus = new Bus("MCA Bus", 190, 189.99m);
            bus.Add(new Card("16Mbs Token Ring", 33, 30));

            chassis.Add(bus);
            chassis.Add(new FloppyDisk("3.5in Floppy", 12, 12));


            Assert.That(cabinet.Name, Is.EqualTo("PC Cabinet"));
            Assert.That(cabinet.NetPrice,Is.EqualTo(390));
            Assert.That(cabinet.DiscountPrice, Is.EqualTo(376.99m));
        }
    }
}
