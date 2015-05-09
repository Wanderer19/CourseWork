using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Solutions.LinkedListTasks.PetShopTask
{
    //наследует от класса Animal, переопределяет его виртуальное свойство
    public class Cat : Animal
    {
        public override string Name { get; set; }
    }
}
