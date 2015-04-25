using DataStructure.Solutions.LinkedListTasks.PetShopTask;
using NUnit.Framework;

namespace DataStructure.Tests
{
    [TestFixture]
    class PetShopTests
    {
        private PetShop shop;

        [SetUp]
        public void SetUp()
        {
            shop = new PetShop();
        }

        [Test]
        public void TestEmptyShop()
        {
            Assert.That(shop.DequeueAny(), Is.Null);
            Assert.That(shop.DequeueCat(), Is.Null);
            Assert.That(shop.DequeueDog(), Is.Null);
        }

        [Test]
        public void TestShopWithOneCat()
        {
            shop.Enqueue(new Cat() { Name = "Cat1" });

            var oldAnimal = shop.DequeueAny();
            Assert.That(oldAnimal is Cat, Is.True);
            Assert.That(oldAnimal.Name, Is.EqualTo("Cat1"));

            TestEmptyPetShop();

            shop.Enqueue(new Cat() { Name = "Cat1" });
            Assert.That(shop.DequeueDog(), Is.Null);
            oldAnimal = shop.DequeueCat();
            Assert.That(oldAnimal is Cat, Is.True);
            Assert.That(oldAnimal.Name, Is.EqualTo("Cat1"));

            TestEmptyPetShop();
        }

        [Test]
        public void TestShopWithOneDog()
        {
            shop.Enqueue(new Dog() { Name = "Dog1" });

            var oldAnimal = shop.DequeueAny();
            Assert.That(oldAnimal is Dog, Is.True);
            Assert.That(oldAnimal.Name, Is.EqualTo("Dog1"));

            TestEmptyPetShop();

            shop.Enqueue(new Dog() { Name = "Dog1" });
            Assert.That(shop.DequeueCat(), Is.Null);
            oldAnimal = shop.DequeueDog();
            Assert.That(oldAnimal is Dog, Is.True);
            Assert.That(oldAnimal.Name, Is.EqualTo("Dog1"));

            TestEmptyPetShop();
        }

        [Test]
        public void TestShopWithManyAnimals()
        {
            shop.Enqueue(new Cat() { Name = "Cat1" });
            shop.Enqueue(new Dog() { Name = "Dog1" });
            shop.Enqueue(new Cat() { Name = "Cat2" });
            shop.Enqueue(new Dog() { Name = "Dog2" });
            shop.Enqueue(new Dog() { Name = "Dog3" });
            shop.Enqueue(new Cat() { Name = "Cat3" });

            var animal = shop.DequeueAny();
            Assert.That(animal is Cat, Is.True);
            Assert.That(animal.Name, Is.EqualTo("Cat1"));

            animal = shop.DequeueCat();
            Assert.That(animal is Cat, Is.True);
            Assert.That(animal.Name, Is.EqualTo("Cat2"));

            animal = shop.DequeueAny();
            Assert.That(animal is Dog, Is.True);
            Assert.That(animal.Name, Is.EqualTo("Dog1"));

            animal = shop.DequeueDog();
            Assert.That(animal is Dog, Is.True);
            Assert.That(animal.Name, Is.EqualTo("Dog2"));

            animal = shop.DequeueDog();
            Assert.That(animal is Dog, Is.True);
            Assert.That(animal.Name, Is.EqualTo("Dog3"));

            animal = shop.DequeueDog();
            Assert.That(animal, Is.Null);

            animal = shop.DequeueCat();
            Assert.That(animal is Cat, Is.True);
            Assert.That(animal.Name, Is.EqualTo("Cat3"));

            TestEmptyPetShop();
        }

        private void TestEmptyPetShop()
        {
            Assert.That(shop.DequeueAny(), Is.Null);
            Assert.That(shop.DequeueCat(), Is.Null);
            Assert.That(shop.DequeueDog(), Is.Null);
        }
    }
}
