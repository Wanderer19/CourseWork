namespace DataStructure.Solutions.LinkedListTasks.PetShopTask
{
    //абстрактный класс. Его экземпляры создавать нельзя, нужен  в качестве базы для наследников.
    public abstract class Animal
    {
        //виртуальное свойство, которое можно переопределить в наследниках
        public virtual string Name { get; set; }
    }
}
