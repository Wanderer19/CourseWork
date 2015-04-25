using System;
using DataStructure.Solutions.LinkedListTasks.LinkedListUtils;

namespace DataStructure.Solutions.LinkedListTasks.PetShopTask
{
    public class PetShop
    {
        private readonly LinkedList<Animal> animals;

        public PetShop()
        {
            animals = new LinkedList<Animal>();
        }

        public void Enqueue(Animal animal)
        {
            animals.EmplaceBack(animal);
        }

        public Animal DequeueAny()
        {
            return Dequeue((animal) => animal.Value is Cat || animal.Value is Dog);
        }

        public Animal DequeueDog()
        {
            return Dequeue((animal) => animal.Value is Dog);
        }

        public Animal DequeueCat()
        {
            return Dequeue((animal) => animal.Value is Cat);
        }

        public Animal Dequeue(Func<LinkedListItem<Animal>, bool> comp)
        {
            var first = animals.First;
            while (first != null)
            {
                if (comp(first))
                {
                    animals.Remove(first);
                    return first.Value;
                }
                first = first.Next;
            }

            return null;
        }
    }
}
